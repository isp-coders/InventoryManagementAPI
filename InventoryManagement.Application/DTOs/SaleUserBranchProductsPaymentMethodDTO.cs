using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.DTOs
{
    public class SaleUserBranchProductsPaymentMethodDTO
    {
        public SaleUserBranchProductsCustomerInfoDTO SaleUserBranchProductsDTO { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }
    }
}
