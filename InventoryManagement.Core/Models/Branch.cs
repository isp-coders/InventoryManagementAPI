using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagement.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Location { get; set; }
        [JsonIgnore]
        public List<SalesDetails> Sales { get; set; }
        [JsonIgnore]
        public List<User> Users { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; }

        public Branch()
        {
            Sales = new List<SalesDetails>();
            Users = new List<User>();
            Products = new List<Product>();
        }
    }
}
