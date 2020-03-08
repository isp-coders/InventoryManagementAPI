using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoeShop.Data;
using ShoeShop.DTOs;
using ShoeShop.Models;
using ShoeShop.ModelViews;
using ShoeShop.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repositories
{
    public class NormalSatisRepository : INormalSatisRepository
    {
        private readonly ShoeShopContext _context;
        private readonly IMapper _mapper;

        public NormalSatisRepository(ShoeShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductViewDto> GetProductDetails(string ProductFullCode)
        {
            return await _mapper.ProjectTo<ProductViewDto>(_context.Products.Include(inc => inc.Color).Include(inc => inc.Branch)).SingleOrDefaultAsync(si => si.ProductFullCode == ProductFullCode);
        }

        public async Task SellProducts(ProductSellingDto productSellingDto)
        {

            // Sale is the main object that connects all other classes
            Sale sale = new Sale { Date = DateTime.Now, Total = productSellingDto.Total };

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
                       _context.Products.Find(Id).Count -= fe.Count;
                       saleProducts.Add(new SaleProduct { Sale = sale, ProductId = Id, ProductCount = fe.Count });
                   });

               });
            sale.SaleProducts.AddRange(saleProducts);


            // Sale-PaymentMethod Relationship / Many-to-Many
            List<int> paymentMethodIds = productSellingDto.PaymentMethodIds;
            List<SalePaymentMethod> salePaymentMethods = new List<SalePaymentMethod>();
            paymentMethodIds.ForEach(Id =>
            {
                SalePaymentMethod salePaymentMethodProperties = productSellingDto.SalePaymentMethods.Find(fi => fi.PaymentMethodId == Id);
                salePaymentMethods.Add(new SalePaymentMethod { Sale = sale, Receipt = productSellingDto.Receipt, PaymentMethodId = Id, Amount = salePaymentMethodProperties.Amount, DefferedPaymentCount = salePaymentMethodProperties.DefferedPaymentCount });
            });
            sale.SalePaymentMethods.AddRange(salePaymentMethods);


            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SaleUserBranchProductsDTO>> GetSelledProductsByUserId(int UserId, DateTime? StartDate, DateTime? EndDate)
        {
            if (StartDate != DateTime.MinValue)
                return await _mapper.ProjectTo<SaleUserBranchProductsDTO>(_context.Sales.Where(wh => wh.UserId == UserId && wh.Date >= StartDate && wh.Date <= EndDate)).ToListAsync();
            else
                return await _mapper.ProjectTo<SaleUserBranchProductsDTO>(_context.Sales.Where(wh => wh.UserId == UserId)).ToListAsync();
        }
    }
}
