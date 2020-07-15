using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Services.BranchesService.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.SalesService.DTOs
{
    public class SalesDetailsDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }

        public int BranchId { get; set; }
        public BranchDto Branch { get; set; }
        public List<SaleProductDto> SaleProducts { get; set; }
        public List<SalePaymentMethodDto> SalePaymentMethods { get; set; }
        public SalesDetailsDto()
        {
            SaleProducts = new List<SaleProductDto>();
            SalePaymentMethods = new List<SalePaymentMethodDto>();
        }
    }
}
