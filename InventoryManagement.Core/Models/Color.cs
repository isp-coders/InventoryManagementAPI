using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public string ShortenColor { get; set; }

        public List<Product> Products { get; set; }
    }
}
