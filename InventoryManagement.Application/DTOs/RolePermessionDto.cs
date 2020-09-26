using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.DTOs
{
    public class RolePermessionDto
    {
        public int Id { get; set; }
        public string RoleKey { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Translate { get; set; }
        public string URL { get; set; }
        public int ParentId { get; set; }
        public bool IsParent { get; set; }
        public int Priority { get; set; }
    }
}
