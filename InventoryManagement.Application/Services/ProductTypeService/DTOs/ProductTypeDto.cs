using InventoryManagement.Application.Services.ProductService.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.ProductTypeService.DTOs
{
    public class ProductTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDto> Products { get; set; }
        public List<ProductTypeAndPropertyDto> ProductTypeAndProperties { get; set; }
    }
}
