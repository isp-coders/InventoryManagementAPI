using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.SalesService.DTOs
{
    public class RefundProductsDto
    {
        public int SaleIdOfOldProdcuts { get; set; }
        public List<int> ProductIdListOfPreviouslyTakenProducts { get; set; }
        public decimal Total { get; set; }
        public int CustomerInfoId { get; set; }
    }
}
