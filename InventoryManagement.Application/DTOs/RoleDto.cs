using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.DTOs
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string PrivilegesList { get; set; }

        public List<UserRoleDto> UserRoles { get; set; }
    }
}
