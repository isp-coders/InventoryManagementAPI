using InventoryManagement.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Data;
using InventoryManagement.Models;
using InventoryManagement.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Repositories
{
    public class ProductsRepository : Repository<Product>, IProductRepository
    {
        private readonly InventoryManagementDbContext _context;

        public ProductsRepository(InventoryManagementDbContext context): base(context)
        {
            _context = context;
        }
    }
}
