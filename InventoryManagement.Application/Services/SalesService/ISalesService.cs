using ShoeShop.DTOs;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.SalesService
{
    public interface ISalesService : IService<SalesDetails>
    {
        ProductViewDto GetProductDetails(string ProductFullCode);
        Task SellProducts(ProductSellingDto productSellingDto);
        List<SaleUserBranchProductsDTO> GetSelledProductsByUserId(int UserId, DateTime? StartDate, DateTime? EndDate);
    }
}
