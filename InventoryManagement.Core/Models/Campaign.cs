using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagement.Core.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int Percent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        public List<SaleDetailsAndProduct> saleDetailsAndProducts { get; set; }
    }
}
