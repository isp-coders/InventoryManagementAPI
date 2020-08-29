using InventoryManagement.Core.IRepositories;
using InventoryManagement.Data;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace InventoryManagement.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly InventoryManagementDbContext _context;
        public UserRepository(InventoryManagementDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
