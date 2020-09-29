using InventoryManagement.Application.Services.ProductTypeService.DTOs;
using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.ProductTypeService
{
    public interface IProductTypeService : IService<ProductType, ProductTypeDto>
    {
    }
}
