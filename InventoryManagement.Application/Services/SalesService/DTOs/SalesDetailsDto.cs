using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Services.BranchesService.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.SalesService.DTOs
{
    public class SalesDetailsDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }

        public int BranchId { get; set; }
        public BranchDto Branch { get; set; }
        public int? CustomerInfoId { get; set; }
        public CustomerInfoDto CustomerInfo { get; set; }
        public List<SaleDetailsAndProductDto> SaleDetailsAndProducts { get; set; }
        //[JsonIgnore]
        public List<SalePaymentMethodDto> SalePaymentMethods { get; set; }
        public SalesDetailsDto()
        {
            SaleDetailsAndProducts = new List<SaleDetailsAndProductDto>();
            SalePaymentMethods = new List<SalePaymentMethodDto>();
        }
    }
}
