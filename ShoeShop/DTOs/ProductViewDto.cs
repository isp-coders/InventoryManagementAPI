using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.DTOs
{
    public class ProductViewDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductFullCode { get; set; }
        public string ProductCode { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public bool Gender { get; set; }
        public string Price { get; set; }
        public string ProductYear { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
        public string BranchName { get; set; }
        public int SellingPrice { get; set; }
        public int TempId { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public string Date { get; set; }
    }
}
