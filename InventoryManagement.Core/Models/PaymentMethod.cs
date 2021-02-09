using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagement.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string PaymentName { get; set; }
        public bool PaymentType { get; set; }
        public List<SalePaymentMethod> SalePaymentMethods { get; set; }

    }
}
