using InventoryManagement.Application.Services.ProductTypeService.DTOs;
using InventoryManagement.Core.Models;
using InventoryManagement.Utils.Response;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.ProductTypeService
{
    public interface IProductTypeService : IService<ProductType, ProductTypeDto>
    {
        Task<UIResponse> AddPropertiesToProductType(AddPropertiesToProductTypeDto addPropertiesToProductTypeDto);
    }
}
