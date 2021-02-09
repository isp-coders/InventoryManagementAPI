using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Color
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string ColorName { get; set; }
        [StringLength(30)]
        public string ShortenColor { get; set; }

        public List<Product> Products { get; set; }
    }
}
