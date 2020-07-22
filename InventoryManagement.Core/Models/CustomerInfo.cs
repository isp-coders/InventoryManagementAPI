using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Models
{
    public class CustomerInfo
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public List<SalePaymentMethod> SalePaymentMethods { get; set; }
    }
}
