using ShoeShop.DTOs;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repositories.IRepositories
{
    public interface INormalSatisRepository
    {
        Task<ProductViewDto> GetProductDetails(string ProductFullCode);
        Task SellProducts(ProductSellingDto productSellingDto);
        Task<List<SaleUserBranchProductsDTO>> GetSelledProductsByUserId(int UserId, DateTime? StartDate, DateTime? EndDate);
    }
}
