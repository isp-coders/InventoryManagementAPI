using InventoryManagement.Application.Services.BranchesService.DTOs;
using InventoryManagement.Application.Services.ColorService.DTOs;
using InventoryManagement.Application.Services.SalesService.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.ProductService.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductFullCode { get; set; }
        public string ProductCode { get; set; }

        public int ColorId { get; set; }
        public ColorDto Color { get; set; }
        public bool Gender { get; set; }
        public decimal Price { get; set; }
        public decimal SellingPrice { get; set; }
        public string ProductYear { get; set; }
        public float Size { get; set; }
        public int Count { get; set; }

        public int? BranchId { get; set; }
        public BranchDto Branch { get; set; }

        public List<SaleDetailsAndProductDto> SaleDetailsAndProducts { get; set; }
    }
}
