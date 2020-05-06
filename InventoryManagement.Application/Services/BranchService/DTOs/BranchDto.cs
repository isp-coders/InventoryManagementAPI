using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.BranchesService.DTOs
{
    public class BranchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public List<SalesDetails> Sales { get; set; }
        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }

        public BranchDto()
        {
            Sales = new List<SalesDetails>();
            Users = new List<User>();
            Products = new List<Product>();
        }
    }
}
