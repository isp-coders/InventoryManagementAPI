using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.DTOs
{
    public class PaymentDetailsDto
    {
        public int PaymentId { get; set; }
        public string PaymentName { get; set; }
        public bool PaymentType { get; set; }
        public int DefferedPaymentCount { get; set; }
        public string Receipt { get; set; }
        public double Amount { get; set; }
    }
}
