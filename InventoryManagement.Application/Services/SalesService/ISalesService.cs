using DevExtreme.AspNet.Data.ResponseModel;
using InventoryManagement.Application.Services.SalesService.DTOs;
using InventoryManagement.DTOs;
using InventoryManagement.Models;
using Sample;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.SalesService
{
    public interface ISalesService : IService<SalesDetails, SalesDetailsDto>
    {
        ProductViewDto GetProductDetails(string ProductFullCode);
        Task SellProducts(ProductSellingDto productSellingDto);
        LoadResult GetSelledProductsByUserId(int UserId, DataSourceLoadOptions loadOptions);
    }
}
