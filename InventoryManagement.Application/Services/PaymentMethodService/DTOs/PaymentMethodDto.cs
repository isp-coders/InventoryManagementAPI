using InventoryManagement.Application.Services.SalesService.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.PaymentMethodService.DTOs
{
    public class PaymentMethodDto
    {
        public int Id { get; set; }
        public string PaymentName { get; set; }
        public bool PaymentType { get; set; }
        public List<SalePaymentMethodDto> SalePaymentMethods { get; set; }
    }
}
