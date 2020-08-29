using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class SaleDetailsAndProduct
    {
        public int SaleId { get; set; }
        public SalesDetails Sale { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; }
    }
}
