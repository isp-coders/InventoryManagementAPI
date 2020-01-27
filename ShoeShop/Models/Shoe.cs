using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeShop.Models
{
    public class Shoe
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductFullCode { get; set; }
        public string ProductCode { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }
        public bool Gender { get; set; }
        public double Price { get; set; }
        //public double SellingPrice { get; set; }
        public DateTime ProductYear { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }

        public Branch Branch { get; set; }

        public int SaleId { get; set; }
        public Sale Sale { get; set; }
    }
}
