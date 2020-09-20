using InventoryManagement.Core.IRepositories;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Repositories.IRepositories
{
    public interface ISalesRepository : IRepository<SalesDetails>
    {
        IQueryable<SalesDetails> GetSaleDetailsWithSubProperties();
        //Task<ProductViewDto> GetProductDetails(string ProductFullCode);
        //Task SellProducts(ProductSellingDto productSellingDto);
        //Task<List<SaleUserBranchProductsDTO>> GetSelledProductsByUserId(int UserId, DateTime? StartDate, DateTime? EndDate);
    }
}
