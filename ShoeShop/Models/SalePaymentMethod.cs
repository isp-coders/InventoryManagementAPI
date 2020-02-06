using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Models
{
    public class SalePaymentMethod
    {
        public int DefferedPaymentCount { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
        public int PaymentMethodId { get; set; }
        public double Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
