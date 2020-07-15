using InventoryManagement.Application.Services.ProductService.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.ProductService
{
    public interface IProductService : IService<Product,ProductDto>
    {
    }
}
