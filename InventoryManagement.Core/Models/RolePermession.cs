using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagement.Models
{
    public class RolePermession
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string RoleKey { get; set; }
        public string Icon { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Translate { get; set; }
        [StringLength(50)]
        public string URL { get; set; }
        public int ParentId { get; set; }
        public bool IsParent { get; set; }
        public int Priority { get; set; }

        //public long? RolePriority { get; set; }
        //public string ControllerName { get; set; }
        //public string ActionName { get; set; }


        public List<RoleAndRolePermession> RoleAndRolePermessions { get; set; }
    }
}
