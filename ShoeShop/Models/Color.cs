using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public int ShortenColor { get; set; }

        public int ShoeId { get; set; }
        public Shoe Shoe { get; set; }
    }
}
