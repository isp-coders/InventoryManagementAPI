using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.DTOs
{
    public class SoledProductDetailsDto
    {
        public string ProductName { get; set; }
        public string ProductBarcode { get; set; }
        public string ProductCode { get; set; }
        public string ColorName { get; set; }
        public int Gender { get; set; }
        public string ProductYear { get; set; }
        public float Size { get; set; }
        public int ProductCount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
        public string BranchName { get; set; }
    }
}
