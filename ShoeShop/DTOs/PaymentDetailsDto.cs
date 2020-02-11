using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.DTOs
{
    public class PaymentDetailsDto
    {
        public string PaymentName { get; set; }
        public bool PaymentType { get; set; }
        public int DefferedPaymentCount { get; set; }
        public string Receipt { get; set; }
        public double Amount { get; set; }
    }
}
