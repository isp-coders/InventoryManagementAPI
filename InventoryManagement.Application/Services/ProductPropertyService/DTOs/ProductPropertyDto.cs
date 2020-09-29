using InventoryManagement.Application.Services.ProductTypeService.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.ProductPropertyService.DTOs
{
    public class ProductPropertyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<ProductTypeAndPropertyDto> ProductTypeAndProperties { get; set; }
    }
}
