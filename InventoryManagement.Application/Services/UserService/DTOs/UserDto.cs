using InventoryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.UserService.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public UserStatus UserStatus { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public DateTime? LastSuccesfulLoginDate { get; set; }
        public string Salt { get; set; }
        //public string Roles { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? BranchId { get; set; }
    }
}
