using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeShop.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Type { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }

    }
}
