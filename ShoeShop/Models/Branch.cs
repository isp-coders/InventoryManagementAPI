using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeShop.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public int SaleId { get; set; }
        public Sale Sale { get; set; }

        public int? ShoeId { get; set; }
        public Shoe Shoe { get; set; }
    }
}
