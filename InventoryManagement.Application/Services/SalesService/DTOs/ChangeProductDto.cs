using InventoryManagement.Application.DTOs;
using InventoryManagement.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.SalesService.DTOs
{
    public class ChangeProductDto
    {
        public int SaleIdOfOldProdcuts { get; set; }
        public List<int> ProductIdListOfPreviouslyTakenProducts { get; set; }
        public NewProductListToTakeDto newProductListToTake { get; set; }
        public decimal Total { get; set; }
        public List<PaymentDetailsDto> paymentDetails { get; set; }
        public CustomerInfoDto customerInfoDto { get; set; }
    }
}
