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

        public List<Sale> Sales { get; set; }
        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }

        public Branch()
        {
            Sales = new List<Sale>();
            Users = new List<User>();
            Products = new List<Product>();
        }
    }
}
