using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Models
{
    public class RolePermession
    {
        public int Id { get; set; }
        public string RoleKey { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Translate { get; set; }
        public string URL { get; set; }
        public string ParentId { get; set; }
        public bool IsParent { get; set; }

        //public long? RolePriority { get; set; }
        //public string ControllerName { get; set; }
        //public string ActionName { get; set; }


        public List<RoleAndRolePermession> RoleAndRolePermessions { get; set; }
    }
}
