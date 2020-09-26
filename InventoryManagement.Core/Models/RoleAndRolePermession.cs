using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InventoryManagement.Models
{
    public class RoleAndRolePermession
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EditingAuthorities { get; set; }
        public int RolePermessionId { get; set; }
        public RolePermession RolePermession { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
