using InventoryManagement.Core.IRepositories;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repositories.IRepositories
{
    public interface ISalesRepository : IRepository<SalesDetails>
    {
        //Task<ProductViewDto> GetProductDetails(string ProductFullCode);
        //Task SellProducts(ProductSellingDto productSellingDto);
        //Task<List<SaleUserBranchProductsDTO>> GetSelledProductsByUserId(int UserId, DateTime? StartDate, DateTime? EndDate);
    }
}
