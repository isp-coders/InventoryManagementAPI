using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string PrivilegesList { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
