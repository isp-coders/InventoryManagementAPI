using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.DTOs
{
    public class UserRoleDto
    {
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
    }
}
