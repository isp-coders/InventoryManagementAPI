using InventoryManagement.Application.Services.PaymentMethodService.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.SalesService.DTOs
{
    public class SalePaymentMethodDto
    {
        public int DefferedPaymentCount { get; set; }
        public double Amount { get; set; }
        public string Receipt { get; set; }
        public int SaleId { get; set; }
        public SalesDetailsDto Sale { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethodDto PaymentMethod { get; set; }
    }
}
