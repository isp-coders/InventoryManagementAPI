using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using InventoryManagement.Application.Services.SalesService.DTOs;
using InventoryManagement.Core.Enums;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.DTOs;
using InventoryManagement.Models;
using InventoryManagement.Repositories.IRepositories;
using InventoryManagement.Utils.Exceptions;
using InventoryManagement.Utils.Response;
using Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.SalesService
{
    public class SalesService : Service<SalesDetails, SalesDetailsDto>, ISalesService
    {
        private readonly ISalesRepository _SalesRepository;
        private readonly IRepository<Product> _ProductRepository;
        private readonly IRepository<CustomerInfo> _CustomerRepository;
        private readonly IRepository<SalePaymentMethod> _SalePaymentMethod;
        private readonly IRepository<SaleDetailsAndProduct> _SaleDetailsAndProduct;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;
        public SalesService(IRepository<CustomerInfo> _CustomerRepository, ISalesRepository SalesRepository, IRepository<Product> ProductRepository, IRepository<SalePaymentMethod> _SalePaymentMethod, IRepository<SaleDetailsAndProduct> _SaleDetailsAndProduct, IUnitOfWork unitOfWork, IMapper mapper) : base(SalesRepository, mapper)
        {
            _SalesRepository = SalesRepository;
            _ProductRepository = ProductRepository;
            this._CustomerRepository = _CustomerRepository;
            this._SalePaymentMethod = _SalePaymentMethod;
            this._SaleDetailsAndProduct = _SaleDetailsAndProduct;
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ProductViewDto GetProductDetails(string ProductBarcode)
        {
            var result = _ProductRepository.GetQuery(null, null, "Branch,Color,Campaign").FirstOrDefault(si => si.ProductBarcode == ProductBarcode);
            if (result.CampaignId.GetValueOrDefault(0) != 0)
            {
                result.SellingPrice = result.SellingPrice - (result.SellingPrice * (result.Campaign.Percent / 100m));
            }
            return _mapper.Map<ProductViewDto>(result);
        }

        public UIResponse GetSelledProductsByUserId(int UserId, DataSourceLoadOptions loadOptions)
        {
            Expression<Func<SalesDetails, bool>> Where;
            if (UserId != 0)
            {
                Where = wh => wh.UserId == UserId;
            }
            else
            {
                Where = wh => wh.UserId != UserId;
            }

            // Orhan benden satis yaparken musteryi secmek istemisti onun icin where i kaldirdim. tekrar konulmali
            var loadResult = DataSourceLoader.Load(_SalesRepository.GetQuery(null, null, "Branch,User,SaleDetailsAndProducts.Product.Color,SalePaymentMethods.PaymentMethod,CustomerInfo")/*.Where(Where)*/, loadOptions);
            if (loadResult.data.OfType<SalesDetails>().Any())
            {
                loadResult.data = _mapper.Map<List<SaleUserBranchProductsCustomerInfoDTO>>(loadResult.data.Cast<SalesDetails>().ToList());
            }
            UIResponse response = _mapper.Map<UIResponse>(loadResult);
            return response;
        }

        public UIResponse GetCustomerPurchasedProducts(int CustomerInfoId, DataSourceLoadOptions loadOptions)
        {
            var loadResult = DataSourceLoader.Load(_SalesRepository.GetQuery(null, null, "SaleDetailsAndProducts.Product.Branch,SaleDetailsAndProducts.Product.Color,CustomerInfo,SalePaymentMethods.PaymentMethod").Where(wh => wh.CustomerInfoId == CustomerInfoId), loadOptions);
            if (loadResult.data.OfType<SalesDetails>().Any())
            {
                loadResult.data = _mapper.Map<List<SalesDetailsDto>>(loadResult.data.Cast<SalesDetails>().ToList());
            }
            UIResponse response = _mapper.Map<UIResponse>(loadResult);
            return response;
        }

        public async Task SellProducts(ProductSellingDto productSellingDto)
        {
            try
            {
                unitOfWork.BeginTransaction();
                //Create or Use existing Customer Info
                CustomerInfo customerInfo = await CreateOrUsingExistingCustomerInfo(productSellingDto.CustomerInfoId, productSellingDto.CustomerName, productSellingDto.CustomerPhone);
                // Sale is the main object that connects all other classes
                SalesDetails sale = new SalesDetails { CustomerInfo = customerInfo, Date = DateTime.Now, Total = productSellingDto.Total, BranchId = productSellingDto.BranchId, UserId = productSellingDto.UserId };


                // Sale-Product Relationship / Many-to-Many
                await AddProductsToSaleDetails(productSellingDto, sale);


                AddPaymentMethodsToSaleDetails(productSellingDto, sale);

                await _SalesRepository.PostEntity(sale);

                await _SalesRepository.SaveChangesAsync();

                unitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                unitOfWork.RollBackTransaction();
                throw e;
            }


        }

        private static void AddPaymentMethodsToSaleDetails(ProductSellingDto productSellingDto, SalesDetails sale)
        {
            // Sale-PaymentMethod Relationship / Many-to-Many
            List<int> paymentMethodIds = productSellingDto.PaymentMethodIds;
            List<SalePaymentMethod> salePaymentMethods = new List<SalePaymentMethod>();
            paymentMethodIds.ForEach(Id =>
            {
                SalePaymentMethod salePaymentMethodProperties = productSellingDto.SalePaymentMethods.Find(fi => fi.PaymentMethodId == Id);
                salePaymentMethods.Add(new SalePaymentMethod { Sale = sale, Receipt = productSellingDto.Receipt, PaymentMethodId = Id, /*CustomerInfo = customerInfo, */Amount = salePaymentMethodProperties.Amount, DefferedPaymentCount = salePaymentMethodProperties.DefferedPaymentCount });
            });


            sale.SalePaymentMethods.AddRange(salePaymentMethods);
        }


        private async Task AddProductsToSaleDetails(ProductSellingDto productSellingDto, SalesDetails sale)
        {
            ProductIdsAndPrices productsPricesAndIdsAndCampaingId = productSellingDto.ProductIdsAndPricesAndCampaignIds;
            List<SaleDetailsAndProduct> saleProducts = new List<SaleDetailsAndProduct>();

            foreach (var (Id, index) in productsPricesAndIdsAndCampaingId.ProductIds.Select((v, i) => (v, i)))
            {
                // Substract the soled products' count from the product table
                Product entity = (await _ProductRepository.FindEntity(Id));
                if (entity.Count > 0)
                {

                    entity.Count -= 1;
                    int campaignId = productsPricesAndIdsAndCampaingId.CampaignIds[index];
                    saleProducts.Add(new SaleDetailsAndProduct { Sale = sale, ProductId = Id, ProductCount = 1, Price = productsPricesAndIdsAndCampaingId.SellingPrices[index], CampaignId = campaignId != 0 ? campaignId : null });
                }
                else
                {
                    throw new InventoryManagementException("EXCEPTIONS.NO_ENOUGHT_COUNT", HttpStatusCode.BadRequest);
                }
            }
            if (saleProducts.Count > 0)
                sale.SaleDetailsAndProducts.AddRange(saleProducts);
        }

        public async Task<UIResponse> RefundProducts(RefundProductsDto refundProductsDto)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var SaleDetailsOfOldProdcuts = _SalesRepository.GetQuery(gq => gq.Id == refundProductsDto.SaleIdOfOldProdcuts, null).First();
                SaleDetailsOfOldProdcuts.RefundAmount += refundProductsDto.Total;

                SalesDetails newSalesDetails = new SalesDetails { BranchId = SaleDetailsOfOldProdcuts.BranchId, Date = DateTime.Now, Total = (refundProductsDto.Total), UserId = SaleDetailsOfOldProdcuts.UserId };


                foreach (var productId in refundProductsDto.ProductIdListOfPreviouslyTakenProducts)
                {
                    SaleDetailsAndProduct saleDetailsAndProduct = _SaleDetailsAndProduct.GetQuery(gq => gq.SaleId == refundProductsDto.SaleIdOfOldProdcuts && gq.ProductId == productId, null, "Product").First();
                    saleDetailsAndProduct.Operations = SaleOperation.RETURNED;
                    saleDetailsAndProduct.Product.Count += 1;
                    _SaleDetailsAndProduct.PutEntity(saleDetailsAndProduct);
                    _ProductRepository.PutEntity(saleDetailsAndProduct.Product);
                    newSalesDetails.SaleDetailsAndProducts.Add(new SaleDetailsAndProduct { ProductId = productId, CampaignId = saleDetailsAndProduct.CampaignId, Operations = SaleOperation.RETURNED, Price = saleDetailsAndProduct.Price, ProductCount = 1 });
                }

                _SalesRepository.PutEntity(SaleDetailsOfOldProdcuts);
                await _SalesRepository.PostEntity(newSalesDetails);

                await _SaleDetailsAndProduct.SaveChangesAsync();
                unitOfWork.CommitTransaction();

                return new UIResponse { };
            }
            catch (Exception e)
            {
                unitOfWork.RollBackTransaction();
                throw;
            }
        }

        public async Task<UIResponse> ChangeProducts(ChangeProductDto changeProductRequestDto)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var SaleDetailsOfOldProdcuts = _SalesRepository.GetQuery(gq => gq.Id == changeProductRequestDto.SaleIdOfOldProdcuts).First();

                //Create or Use existing Customer Info
                CustomerInfo customerInfo = await CreateOrUsingExistingCustomerInfo(changeProductRequestDto.customerInfoDto.Id, changeProductRequestDto.customerInfoDto.CustomerName, changeProductRequestDto.customerInfoDto.CustomerPhone);

                SalesDetails newSaleDetailsForNewTakenProducts = new SalesDetails { CustomerInfo = customerInfo, Date = DateTime.Now, Total = changeProductRequestDto.Total, BranchId = SaleDetailsOfOldProdcuts.BranchId, UserId = SaleDetailsOfOldProdcuts.UserId };

                AddProductsToSaleDetails(changeProductRequestDto.newProductListToTake, newSaleDetailsForNewTakenProducts);



                AddPaymentDetailsToSaleDetails(changeProductRequestDto.paymentDetails, newSaleDetailsForNewTakenProducts);

                await _SalesRepository.PostEntity(newSaleDetailsForNewTakenProducts);


                if (changeProductRequestDto.Total < 0)
                {
                    SaleDetailsOfOldProdcuts.RefundAmount += Math.Abs(changeProductRequestDto.Total);
                    _SalesRepository.PutEntity(SaleDetailsOfOldProdcuts);
                }


                foreach (var productId in changeProductRequestDto.ProductIdListOfPreviouslyTakenProducts)
                {

                    var SaleDetailsAndProduct = _SaleDetailsAndProduct.GetQuery(null, null, "Product").First(gq => gq.SaleId == changeProductRequestDto.SaleIdOfOldProdcuts && gq.ProductId == productId);
                    SaleDetailsAndProduct.Operations = SaleOperation.CHANGED;
                    SaleDetailsAndProduct.Product.Count += 1;
                    _SaleDetailsAndProduct.PutEntity(SaleDetailsAndProduct);
                    _ProductRepository.PutEntity(SaleDetailsAndProduct.Product);
                }

                await _SaleDetailsAndProduct.SaveChangesAsync();
                unitOfWork.CommitTransaction();
                return new UIResponse { };
            }
            catch (Exception e)
            {
                unitOfWork.RollBackTransaction();
                throw;
            }
        }

        private void AddProductsToSaleDetails(NewProductListToTakeDto newProductListToTake, SalesDetails newSaleDetailsForNewTakenProducts)
        {
            List<SaleDetailsAndProduct> saleDetailsAndProducts = new List<SaleDetailsAndProduct>();

            foreach (var (productId, index) in newProductListToTake.ProductIdList.Select((v, i) => (v, i)))
            {
                // Substract the soled products' count from the product table

                Product product = _ProductRepository.GetQuery(gq => gq.Id == productId).First();
                if (product.Count > 0)
                {

                    product.Count -= 1;
                    _ProductRepository.PutEntity(product);


                    saleDetailsAndProducts.Add(new SaleDetailsAndProduct { Operations = SaleOperation.TakenInsteadOfOldProducts, ProductId = productId, ProductCount = 1, Price = newProductListToTake.ProductPrices[index], CampaignId = product.CampaignId });
                }
                else
                {
                    throw new InventoryManagementException("EXCEPTIONS.NO_ENOUGHT_COUNT", HttpStatusCode.BadRequest);
                }
            }
            if (saleDetailsAndProducts.Count > 0)
                newSaleDetailsForNewTakenProducts.SaleDetailsAndProducts.AddRange(saleDetailsAndProducts);
        }



        private async Task<CustomerInfo> CreateOrUsingExistingCustomerInfo(int CustomerInfoId, string CustomerName, string CustomerPhone)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            if (CustomerInfoId == 0)
            {
                if (!(String.IsNullOrEmpty(CustomerName) && String.IsNullOrEmpty(CustomerPhone)))
                {
                    customerInfo.CustomerName = CustomerName;
                    customerInfo.CustomerPhone = CustomerPhone;
                }

            }
            else
            {
                customerInfo = await _CustomerRepository.FindEntity(CustomerInfoId);
            }

            return customerInfo;
        }

        private void AddPaymentDetailsToSaleDetails(List<PaymentDetailsDto> paymentDetailsDto, SalesDetails newSaleDetailsForNewTakenProducts)
        {
            paymentDetailsDto.ForEach(paymentDetails =>
            {
                newSaleDetailsForNewTakenProducts.SalePaymentMethods.Add(new SalePaymentMethod { Sale = newSaleDetailsForNewTakenProducts, Receipt = paymentDetails.Receipt, PaymentMethodId = paymentDetails.PaymentId, /*CustomerInfo = customerInfo,*/ Amount = paymentDetails.Amount, DefferedPaymentCount = paymentDetails.DefferedPaymentCount });
            });
        }
    }
}
