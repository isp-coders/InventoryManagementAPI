using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.ProductService.DTOs
{
    public class ApplyCampaignRequestDto
    {
        public int CampaignId { get; set; }
        public List<int> ProductsId { get; set; }
    }
}
