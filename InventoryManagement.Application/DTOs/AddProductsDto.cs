using InventoryManagement.Application.Services.ProductService.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.DTOs
{
    public class AddProductsDto
    {
        public List<ProductDto> ExistedProducts { get; set; }
        public List<ProductDto> AddedProducts { get; set; }
        public AddProductsDto()
        {
            ExistedProducts = new List<ProductDto>();
            AddedProducts = new List<ProductDto>();
        }
    }
}
