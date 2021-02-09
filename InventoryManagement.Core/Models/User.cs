using InventoryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InventoryManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string UserCode { get; set; }
        public UserStatus UserStatus { get; set; }
        [StringLength(200)]
        public string Password { get; set; }
        [StringLength(200)]
        public string ImagePath { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(30)]
        public string Cellphone { get; set; }
        public DateTime? LastSuccesfulLoginDate { get; set; }
        [StringLength(100)]
        public string Salt { get; set; }
        //public string Roles { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        public int? BranchId { get; set; }
        public Branch Branch { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public List<SalesDetails> Sales { get; set; }

        public User()
        {
            Sales = new List<SalesDetails>();
        }
    }
}
