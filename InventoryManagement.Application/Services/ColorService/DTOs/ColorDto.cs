using InventoryManagement.Application.Services.ProductService.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.ColorService.DTOs
{
    public class ColorDto
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public string ShortenColor { get; set; }

        //public List<ProductDto> Products { get; set; }
    }
}
