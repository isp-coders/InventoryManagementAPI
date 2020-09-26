using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.DTOs
{
    public class RoleDto
    {
        public int Id { get; set; }
        public int RoleGroupId { get; set; }
        public string RoleName { get; set; }
        public List<int> RolePermessionsIds { get; set; }
        public List<RoleAndRolePermessionDto> RoleAndRolePermessions { get; set; }
        public List<UserDto> Users { get; set; }
        //public List<UserRole> UserRoles { get; set; }
    }
}
