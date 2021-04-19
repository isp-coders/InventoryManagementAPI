using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagement.Models
{
    public class CustomerInfo
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string CustomerName { get; set; }
        [StringLength(20)]
        public string CustomerPhone { get; set; }
        public string AccentInsensitiveCustomerName { get; set; }
        public List<SalesDetails> SalesDetails { get; set; }
        //public List<SalePaymentMethod> SalePaymentMethods { get; set; }
    }
}
