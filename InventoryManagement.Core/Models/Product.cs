using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InventoryManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        [StringLength(100)]
        public string ProductBarcode { get; set; }
        [StringLength(100)]
        public string ProductCode { get; set; }

        public int? ColorId { get; set; }
        public Color Color { get; set; }
        public int Gender { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPrice { get; set; }
        [StringLength(100)]
        public string ProductYear { get; set; }
        public float Size { get; set; }
        public int Count { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }

        public int? BranchId { get; set; }
        public Branch Branch { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public int? CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public List<SaleDetailsAndProduct> SaleDetailsAndProducts { get; set; }
        public Product()
        {
            SaleDetailsAndProducts = new List<SaleDetailsAndProduct>();
        }
    }
}
