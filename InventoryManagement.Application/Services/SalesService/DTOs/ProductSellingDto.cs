using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.DTOs
{
    public class ProductSellingDto
    {
        public int Total { get; set; }
        public int UserId { get; set; }
        public string Receipt { get; set; }
        public int BranchId { get; set; }
        public List<SalePaymentMethod> SalePaymentMethods { get; set; }
        public List<int> PaymentMethodIds { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
