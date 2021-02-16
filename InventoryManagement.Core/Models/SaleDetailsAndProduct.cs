using InventoryManagement.Core.Enums;
using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class SaleDetailsAndProduct
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public SalesDetails Sale { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int? CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public SaleOperation Operations { get; set; }
    }
}
