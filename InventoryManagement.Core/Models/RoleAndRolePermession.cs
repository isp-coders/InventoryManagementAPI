using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Models
{
    public class RoleAndRolePermession
    {
        public int Id { get; set; }
        public int RolePermessionId { get; set; }
        public RolePermession RolePermession { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
