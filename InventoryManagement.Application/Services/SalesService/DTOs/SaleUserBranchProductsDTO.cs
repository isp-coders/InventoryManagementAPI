using InventoryManagement.Application.DTOs;
using InventoryManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.DTOs
{
    public class SaleUserBranchProductsCustomerInfoDTO
    {
        public int Id { get; set; }
        //[JsonIgnore]
        public UserDto User { get; set; }
        public DateTime Date { get; set; }
        //[JsonIgnore]
        public Branch Branch { get; set; }
        public decimal Total { get; set; }
        public decimal RefundAmount { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public List<SoledProductDetailsDto> SoledProductDetails { get; set; }
        public List<PaymentDetailsDto> PaymentDetails { get; set; }
    }
}
