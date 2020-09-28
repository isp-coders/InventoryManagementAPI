using InventoryManagement.Application.Services.ProductPropertyService.DTOs;
using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.ProductPropertyService
{
    public interface IProductPropertyService : IService<ProductProperty, ProductPropertyDto>
    {
    }
}
