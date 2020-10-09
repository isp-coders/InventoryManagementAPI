using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using InventoryManagement.Application.Services.SalesService.DTOs;
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
        private readonly IMapper _mapper;
        public SalesService(IRepository<CustomerInfo> _CustomerRepository, ISalesRepository SalesRepository, IRepository<Product> ProductRepository, IMapper mapper) : base(SalesRepository, mapper)
        {
            _SalesRepository = SalesRepository;
            _ProductRepository = ProductRepository;
            this._CustomerRepository = _CustomerRepository;
            _mapper = mapper;
        }

        public ProductViewDto GetProductDetails(string ProductBarcode)
        {
            //Expression<Func<TEntity, TProperty>> navigationPropertyPath 
            return _mapper.Map<ProductViewDto>(_ProductRepository.GetEntities().FirstOrDefault(si => si.ProductBarcode == ProductBarcode));
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

        public async Task SellProducts(ProductSellingDto productSellingDto)
        {
            // Sale is the main object that connects all other classes
            SalesDetails sale = new SalesDetails { Date = DateTime.Now, Total = productSellingDto.Total };

            sale.BranchId = productSellingDto.BranchId;
            sale.UserId = productSellingDto.UserId;

            #region Unusable Code
            //The Following Code is used when we want to add new records.
            //// Sale-Branch Relationship / One-to-Many
            //Branch branch = productSellingDto.Branch;
            //sale.Branch = branch;

            //// Sale-User Relationship / One-to-Many
            //User user = _context.Users.Find(productSellingDto.UserId);
            //sale.User = user; 
            #endregion


            // Sale-Product Relationship / Many-to-Many
            List<int> productIds = productSellingDto.ProductIds;
            List<SaleDetailsAndProduct> saleProducts = new List<SaleDetailsAndProduct>();
            // We grouped by Id because we want the same products to be saved as one product with their count.
            productIds.GroupBy(Id => Id).Select(se => new { Id = se.Key, Count = se.Count() }).ToList().ForEach(fe =>
            {

                // Substract the soled products' count from the product table
                Product entity = _ProductRepository.FindEntity(fe.Id).Result;
                if (entity.Count >= 0)
                {

                    entity.Count -= fe.Count;
                    saleProducts.Add(new SaleDetailsAndProduct { Sale = sale, ProductId = fe.Id, ProductCount = fe.Count });
                }
                else
                {
                    //throw new ApiException(new UIResponse("EXCEPTIONS.NO_ENOUGHT_COUNT", HttpStatusCode.BadRequest));
                    throw new InventoryManagementException("EXCEPTIONS.NO_ENOUGHT_COUNT", HttpStatusCode.BadRequest);
                }

            });
            sale.SaleDetailsAndProducts.AddRange(saleProducts);


            // Create or Use existing Customer Info
            CustomerInfo customerInfo = new CustomerInfo();
            if (productSellingDto.CustomerInfoId == 0)
            {
                customerInfo.CustomerName = productSellingDto.CustomerName;
                customerInfo.CustomerPhone = productSellingDto.CustomerPhone;
            }
            else
            {
                customerInfo = await _CustomerRepository.FindEntity(productSellingDto.CustomerInfoId);
            }

            // Sale-PaymentMethod Relationship / Many-to-Many
            List<int> paymentMethodIds = productSellingDto.PaymentMethodIds;
            List<SalePaymentMethod> salePaymentMethods = new List<SalePaymentMethod>();
            paymentMethodIds.ForEach(Id =>
            {
                SalePaymentMethod salePaymentMethodProperties = productSellingDto.SalePaymentMethods.Find(fi => fi.PaymentMethodId == Id);
                salePaymentMethods.Add(new SalePaymentMethod { Sale = sale, Receipt = productSellingDto.Receipt, PaymentMethodId = Id, CustomerInfo = customerInfo, Amount = salePaymentMethodProperties.Amount, DefferedPaymentCount = salePaymentMethodProperties.DefferedPaymentCount });
            });




            sale.SalePaymentMethods.AddRange(salePaymentMethods);


            await _SalesRepository.PostEntity(sale);

        }
    }
}
