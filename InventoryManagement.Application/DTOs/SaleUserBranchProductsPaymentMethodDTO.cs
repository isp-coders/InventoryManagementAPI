using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.DTOs
{
    public class SaleUserBranchProductsPaymentMethodDTO
    {
        public SaleUserBranchProductsDTO SaleUserBranchProductsDTO { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }
    }
}
