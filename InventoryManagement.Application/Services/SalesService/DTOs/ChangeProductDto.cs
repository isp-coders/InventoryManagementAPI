using InventoryManagement.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.SalesService.DTOs
{
    public class ChangeProductDto
    {
        public ProductSellingDto productsToChangeWith { get; set; }
        public List<SaleDetailsAndProductDto> purchasedProductsToChange { get; set; }
    }
}
