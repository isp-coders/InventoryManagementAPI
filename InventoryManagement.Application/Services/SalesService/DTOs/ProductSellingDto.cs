using InventoryManagement.Application.Services.SalesService.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.DTOs
{
    public class ProductSellingDto
    {
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public string Receipt { get; set; }
        public int BranchId { get; set; }
        public int CustomerInfoId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public List<SalePaymentMethod> SalePaymentMethods { get; set; }
        public List<int> PaymentMethodIds { get; set; }
        public ProductIdsAndPrices ProductIdsAndPricesAndCampaignIds { get; set; }

    }
}
