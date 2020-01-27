using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeShop.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int? SellerId { get; set; }
        public Seller Seller { get; set; }

        public Branch Branch { get; set; }

        //public PaymentMethod PaymentMethod { get; set; }

        public ICollection<Shoe> Shoes { get; set; }
    }
}
