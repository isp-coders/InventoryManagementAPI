using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.DTOs
{
    public class RoleAndRolePermessionDto
    {
        public int Id { get; set; }
        public string EditingAuthorities { get; set; }
        public int RolePermessionId { get; set; }
        public RolePermessionDto RolePermession { get; set; }
        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
    }
}
