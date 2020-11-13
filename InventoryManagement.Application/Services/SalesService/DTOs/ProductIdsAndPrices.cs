using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.SalesService.DTOs
{
    public class ProductIdsAndPrices
    {
        public List<int> ProductIds { get; set; }
        public List<decimal> SellingPrices { get; set; }
    }
}
