using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductFullCode { get; set; }
        public string ProductCode { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }
        public bool Gender { get; set; }
        public decimal Price { get; set; }
        public decimal SellingPrice { get; set; }
        public string ProductYear { get; set; }
        public float Size { get; set; }
        public int Count { get; set; }

        public int? BranchId { get; set; }
        public Branch Branch { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }


        public List<SaleDetailsAndProduct> SaleDetailsAndProducts { get; set; }
    }
}
