using InventoryManagement.Application.Services.BranchesService.DTOs;
using InventoryManagement.Application.Services.SalesService.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserCode { get; set; }
        public string Password { get; set; }
        //public string Roles { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? BranchId { get; set; }
        public BranchDto Branch { get; set; }

        public List<SalesDetailsDto> Sales { get; set; }
        public List<UserRoleDto> UserRoles { get; set; }

        public UserDto()
        {
            Sales = new List<SalesDetailsDto>();
            UserRoles = new List<UserRoleDto>();
        }
    }
}
