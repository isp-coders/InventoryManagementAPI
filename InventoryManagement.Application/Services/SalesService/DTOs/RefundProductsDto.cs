using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.SalesService.DTOs
{
    public class RefundProductsDto
    {
        public List<int> SaleId { get; set; }
        public List<int> ProductId { get; set; }
    }
}
