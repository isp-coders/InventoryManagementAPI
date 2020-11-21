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
            //Expression<Func<TEntity, TProperty>> navigationPropertyPath 
            return _mapper.Map<ProductViewDto>(_ProductRepository.GetEntities(inc => inc.Branch, inc => inc.Color).FirstOrDefault(si => si.ProductBarcode == ProductBarcode));
        }

        public UIResponse GetSelledProductsByUserId(int UserId, DataSourceLoadOptions loadOptions)
        {

            var loadResult = DataSourceLoader.Load(_SalesRepository.GetSaleDetailsWithSubProperties().Where(wh => wh.UserId == UserId), loadOptions);
            if (loadResult.data.OfType<SalesDetails>().Any())
            {
                loadResult.data = _mapper.Map<List<SaleUserBranchProductsDTO>>(loadResult.data.Cast<SalesDetails>().ToList());
            }
            UIResponse response = _mapper.Map<UIResponse>(loadResult);
            return response;
        }

        public UIResponse GetCustomerPurchasedProducts(int CustomerInfoId, DataSourceLoadOptions loadOptions)
        {
            var loadResult = DataSourceLoader.Load(_SalePaymentMethod.GetEntities(inc => inc.Sale, inc => inc.Sale.SaleDetailsAndProducts.Select(se => se.Product).Select(se => se.Branch), inc => inc.Sale.SaleDetailsAndProducts.Select(se => se.Product).Select(se => se.Color), inc => inc.CustomerInfo, inc => inc.PaymentMethod).Where(wh => wh.CustomerInfoId == CustomerInfoId), loadOptions);
            if (loadResult.data.OfType<SalePaymentMethod>().Any())
            {
                loadResult.data = _mapper.Map<List<SalePaymentMethodDto>>(loadResult.data.Cast<SalePaymentMethod>().ToList());
            }
            UIResponse response = _mapper.Map<UIResponse>(loadResult);
            return response;
        }

        public async Task SellProducts(ProductSellingDto productSellingDto)
        {
            try
            {
                unitOfWork.BeginTransaction();
                // Sale is the main object that connects all other classes
                SalesDetails sale = new SalesDetails { Date = DateTime.Now, Total = productSellingDto.Total, BranchId = productSellingDto.BranchId, UserId = productSellingDto.UserId };


                // Sale-Product Relationship / Many-to-Many
                AddSaleDetails(productSellingDto, sale);


                //Create or Use existing Customer Info
                CustomerInfo customerInfo = await CreateOrUsingExistingCustomerInfo(productSellingDto);

                SavePaymentMethods(productSellingDto, sale, customerInfo);

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

        public async Task<UIResponse> RefundProducts(List<SaleDetailsAndProductDto> saleDetailsAndProductDtos)
        {
            try
            {
                unitOfWork.BeginTransaction();
                foreach (var saleDetailsAndProduct in saleDetailsAndProductDtos)
                {
                    int ProductId = saleDetailsAndProduct.ProductId;

                    var SaleDetails = _SalesRepository.GetQuery(gq => gq.Id == saleDetailsAndProduct.SaleId).First();
                    SaleDetails.RefundAmount += saleDetailsAndProduct.Price;
                    _SalesRepository.PutEntity(SaleDetails);

                    var SaleDetailsAndProduct = _SaleDetailsAndProduct.GetEntities(ge => ge.Product).First(gq => gq.SaleId == saleDetailsAndProduct.SaleId && gq.ProductId == ProductId);
                    SaleDetailsAndProduct.Operations = SaleOperation.RETURNED;
                    SaleDetailsAndProduct.Product.Count += 1;

                    _SaleDetailsAndProduct.PutEntity(SaleDetailsAndProduct);
                    
                }
                await _SaleDetailsAndProduct.SaveChangesAsync();
                unitOfWork.CommitTransaction();

                return new UIResponse { };
            }
            catch (Exception e)
            {
                unitOfWork.RollBackTransaction();
                throw e;
            }
        }

        public async Task<UIResponse> ChangeProducts(ChangeProductDto changeProductDto)
        {
            try
            {
                unitOfWork.BeginTransaction();
                decimal total = 0;
                if (changeProductDto.productsToChangeWith.Total > 0)
                    total = changeProductDto.productsToChangeWith.Total;
                else
                    total = 0;
                SalesDetails sale = new SalesDetails { Date = DateTime.Now, Total = total, BranchId = changeProductDto.productsToChangeWith.BranchId, UserId = changeProductDto.productsToChangeWith.UserId };

                AddSaleDetails(changeProductDto.productsToChangeWith, sale);


                //Create or Use existing Customer Info
                CustomerInfo customerInfo = await CreateOrUsingExistingCustomerInfo(changeProductDto.productsToChangeWith);

                SavePaymentMethods(changeProductDto.productsToChangeWith, sale, customerInfo);

                await _SalesRepository.PostEntity(sale);



                if (changeProductDto.productsToChangeWith.Total < 0)
                {
                    var SaleDetails = _SalesRepository.GetQuery(gq => gq.Id == changeProductDto.purchasedProductsToChange[0].SaleId).First();
                    SaleDetails.RefundAmount += Math.Abs(changeProductDto.productsToChangeWith.Total);
                    _SalesRepository.PutEntity(SaleDetails);
                }


                foreach (var saleDetailsAndProduct in changeProductDto.purchasedProductsToChange)
                {
                    int ProductId = saleDetailsAndProduct.ProductId;



                    var SaleDetailsAndProduct = _SaleDetailsAndProduct.GetEntities(ge => ge.Product).First(gq => gq.SaleId == saleDetailsAndProduct.SaleId && gq.ProductId == ProductId);
                    SaleDetailsAndProduct.Operations = SaleOperation.CHANGED;
                    SaleDetailsAndProduct.Product.Count += 1;
                    _SaleDetailsAndProduct.PutEntity(SaleDetailsAndProduct);
                }

                await _SaleDetailsAndProduct.SaveChangesAsync();
                unitOfWork.CommitTransaction();
                return new UIResponse { };
            }
            catch (Exception e)
            {
                unitOfWork.RollBackTransaction();
                throw e;
            }
        }

        private void AddSaleDetails(ProductSellingDto productSellingDto, SalesDetails sale)
        {
            ProductIdsAndPrices productsPriceAndIds = productSellingDto.ProductIdsAndPrices;
            List<SaleDetailsAndProduct> saleProducts = new List<SaleDetailsAndProduct>();

            foreach (var (Id, index) in productsPriceAndIds.ProductIds.Select((v, i) => (v, i)))
            {
                // Substract the soled products' count from the product table
                Product entity = _ProductRepository.FindEntity(Id).Result;
                if (entity.Count > 0)
                {

                    entity.Count -= 1;
                    saleProducts.Add(new SaleDetailsAndProduct { Sale = sale, ProductId = Id, ProductCount = 1, Price = productsPriceAndIds.SellingPrices[index] });
                }
                else
                {
                    throw new InventoryManagementException("EXCEPTIONS.NO_ENOUGHT_COUNT", HttpStatusCode.BadRequest);
                }
            }
            if (saleProducts.Count > 0)
                sale.SaleDetailsAndProducts.AddRange(saleProducts);
        }

        private async Task<CustomerInfo> CreateOrUsingExistingCustomerInfo(ProductSellingDto productSellingDto)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            if (productSellingDto.CustomerInfoId == 0)
            {
                if (!(String.IsNullOrEmpty(productSellingDto.CustomerName) && String.IsNullOrEmpty(productSellingDto.CustomerPhone)))
                {
                    customerInfo.CustomerName = productSellingDto.CustomerName;
                    customerInfo.CustomerPhone = productSellingDto.CustomerPhone;
                }

            }
            else
            {
                customerInfo = await _CustomerRepository.FindEntity(productSellingDto.CustomerInfoId);
            }

            return customerInfo;
        }

        private static void SavePaymentMethods(ProductSellingDto productSellingDto, SalesDetails sale, CustomerInfo customerInfo)
        {
            // Sale-PaymentMethod Relationship / Many-to-Many
            List<int> paymentMethodIds = productSellingDto.PaymentMethodIds;
            List<SalePaymentMethod> salePaymentMethods = new List<SalePaymentMethod>();
            paymentMethodIds.ForEach(Id =>
            {
                SalePaymentMethod salePaymentMethodProperties = productSellingDto.SalePaymentMethods.Find(fi => fi.PaymentMethodId == Id);
                salePaymentMethods.Add(new SalePaymentMethod { Sale = sale, Receipt = productSellingDto.Receipt, PaymentMethodId = Id, CustomerInfo = customerInfo, Amount = salePaymentMethodProperties.Amount, DefferedPaymentCount = salePaymentMethodProperties.DefferedPaymentCount });
            });


            sale.SalePaymentMethods.AddRange(salePaymentMethods);
        }
    }
}
