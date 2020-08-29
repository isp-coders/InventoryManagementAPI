using InventoryManagement.Core.IRepositories;
using InventoryManagement.Data;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        private readonly InventoryManagementDbContext _context;
        public UserRoleRepository(InventoryManagementDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
