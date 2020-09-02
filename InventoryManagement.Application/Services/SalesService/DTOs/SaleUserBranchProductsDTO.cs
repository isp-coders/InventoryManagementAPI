using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.DTOs
{
    public class SaleUserBranchProductsDTO
    {
        public int Id { get; set; }
        public string UserCode { get; set; }
        public DateTime Date { get; set; }
        public string BranchName { get; set; }
        public decimal Total { get; set; }
        public List<SoledProductDetailsDto> SoledProductDetails { get; set; }
        public List<PaymentDetailsDto> PaymentDetails { get; set; }
    }
}
