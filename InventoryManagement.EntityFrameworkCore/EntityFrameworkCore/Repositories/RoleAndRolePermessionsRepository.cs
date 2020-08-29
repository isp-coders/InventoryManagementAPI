using InventoryManagement.Core.IRepositories;
using InventoryManagement.Data;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class RoleAndRolePermessionsRepository : Repository<RoleAndRolePermession>, IRoleAndRolePermessionsRepository
    {
        private readonly InventoryManagementDbContext _context;

        public RoleAndRolePermessionsRepository(InventoryManagementDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
