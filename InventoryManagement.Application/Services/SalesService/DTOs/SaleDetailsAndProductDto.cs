using InventoryManagement.Application.Services.ProductService.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.SalesService.DTOs
{
    public class SaleDetailsAndProductDto
    {
        public int SaleId { get; set; }
        public SalesDetailsDto Sale { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int ProductCount { get; set; }
    }
}
