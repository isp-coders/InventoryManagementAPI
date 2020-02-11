using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.DTOs
{
    public class SaleUserBranchProductsDTO
    {
        public int Id { get; set; }
        public string UserCode { get; set; }
        public DateTime Date { get; set; }
        public string BranchName { get; set; }
        public double Total { get; set; }
        public List<SoledProductDetailsDto> SoledProductDetails { get; set; }
        public List<PaymentDetailsDto> PaymentDetails { get; set; }
    }
}
