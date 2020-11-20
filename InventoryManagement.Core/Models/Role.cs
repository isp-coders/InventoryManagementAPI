using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Role
    {
        public int Id { get; set; }
        public int RoleGroupId { get; set; }
        [StringLength(50)]
        public string RoleName { get; set; }
        public List<RoleAndRolePermession> RoleAndRolePermessions { get; set; }
        public List<User> Users { get; set; }
    }
}
