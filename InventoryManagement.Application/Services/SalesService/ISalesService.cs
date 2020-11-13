using DevExtreme.AspNet.Data.ResponseModel;
using InventoryManagement.Application.Services.SalesService.DTOs;
using InventoryManagement.DTOs;
using InventoryManagement.Models;
using InventoryManagement.Utils.Response;
using Sample;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.SalesService
{
    public interface ISalesService : IService<SalesDetails, SalesDetailsDto>
    {
        ProductViewDto GetProductDetails(string ProductBarcode);
        Task SellProducts(ProductSellingDto productSellingDto);
        UIResponse GetSelledProductsByUserId(int UserId, DataSourceLoadOptions loadOptions);
        UIResponse GetCustomerPurchasedProducts(int CustomerInfoId, DataSourceLoadOptions loadOptions);
        Task<UIResponse> RefundProducts(List<SaleDetailsAndProductDto> saleDetailsAndProductDtos);
        Task<UIResponse> ChangeProducts(ChangeProductDto changeProductDto);
    }
}
