using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class SalePaymentMethod
    {
        public int DefferedPaymentCount { get; set; }
        public double Amount { get; set; }
        [StringLength(30)]
        public string Receipt { get; set; }
        public int SaleId { get; set; }
        public SalesDetails Sale { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int CustomerInfoId { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
    }
}
