﻿using AutoMapper;
using InventoryManagement.Application.Services.SalesService.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.SalesService
{
    public class SalesService : Service<SalesDetails, SalesDetailsDto>, ISalesService
    {
        private readonly IRepository<SalesDetails> _SalesRepository;
        private readonly IRepository<Product> _ProductRepository;
        private readonly IRepository<CustomerInfo> _CustomerRepository;
        private readonly IMapper _mapper;
        public SalesService(IRepository<CustomerInfo> _CustomerRepository, IRepository<SalesDetails> SalesRepository, IRepository<Product> ProductRepository, IMapper mapper) : base(SalesRepository, mapper)
        {
            _SalesRepository = SalesRepository;
            _ProductRepository = ProductRepository;
            this._CustomerRepository = _CustomerRepository;
            _mapper = mapper;
        }

        public ProductViewDto GetProductDetails(string ProductFullCode)
        {
            //Expression<Func<TEntity, TProperty>> navigationPropertyPath 
            return _mapper.ProjectTo<ProductViewDto>(_ProductRepository.GetEntities()).SingleOrDefault(si => si.ProductFullCode == ProductFullCode);
        }

        public List<SaleUserBranchProductsDTO> GetSelledProductsByUserId(int UserId, DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate != DateTime.MinValue)
                return _mapper.ProjectTo<SaleUserBranchProductsDTO>(_SalesRepository.GetEntities().Where(wh => wh.UserId == UserId && wh.Date >= StartDate && wh.Date <= EndDate)).ToList();
            else
                return _mapper.ProjectTo<SaleUserBranchProductsDTO>(_SalesRepository.GetEntities().Where(wh => wh.UserId == UserId)).ToList();
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
            List<SaleProduct> saleProducts = new List<SaleProduct>();
            // We grouped by Id because we want the same products to be saved as one product with their count.
            productIds.GroupBy(Id => Id).Select(se => new { Ids = se.ToList(), Count = se.Count() }).ToList().ForEach(fe =>
            {
                fe.Ids.ForEach(Id =>
                {
                    // Substract the soled products' count from the product table
                    _ProductRepository.FindEntity(Id).Result.Count -= fe.Count;
                    saleProducts.Add(new SaleProduct { Sale = sale, ProductId = Id, ProductCount = fe.Count });
                });

            });
            sale.SaleProducts.AddRange(saleProducts);


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
