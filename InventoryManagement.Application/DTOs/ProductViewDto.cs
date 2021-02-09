using InventoryManagement.Application.Services.BranchesService.DTOs;
using InventoryManagement.Application.Services.CampaignService.DTOs;
using InventoryManagement.Application.Services.ColorService.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.DTOs
{
    public class ProductViewDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductBarcode { get; set; }
        public string ProductCode { get; set; }
        public int ColorId { get; set; }
        public ColorDto Color { get; set; }
        public int Gender { get; set; }
        public string Price { get; set; }
        public string ProductYear { get; set; }
        public float Size { get; set; }
        public int Count { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
        public string BranchName { get; set; }
        public decimal SellingPrice { get; set; }
        public int TempId { get; set; }
        public int BranchId { get; set; }
        public BranchDto Branch { get; set; }
        public string Date { get; set; }
        public int CampaingId { get; set; }
        public CampaignDto CampaignDto { get; set; }
    }
}
