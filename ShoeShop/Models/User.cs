﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeShop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserCode { get; set; }
        public string Password { get; set; }
        //public string Roles { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? BranchId { get; set; }
        public Branch Branch { get; set; }

        public List<Sale> Sales { get; set; }
        public List<UserRole> UserRoles { get; set; }

        public User()
        {
            Sales = new List<Sale>();
            UserRoles = new List<UserRole>();
        }
    }
}
