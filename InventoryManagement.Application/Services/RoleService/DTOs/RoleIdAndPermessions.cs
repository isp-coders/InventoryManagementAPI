using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.RoleService.DTOs
{
    public class RoleIdAndPermessions
    {
        public int RoleId { get; set; }
        public List<int> RolePermessions { get; set; }
    }
}
