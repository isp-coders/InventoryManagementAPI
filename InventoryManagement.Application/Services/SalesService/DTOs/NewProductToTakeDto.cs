using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.SalesService.DTOs
{
    public class NewProductListToTakeDto
    {
        public List<int> ProductIdList { get; set; }
        public List<int> ProductPrices { get; set; }
    }
}
