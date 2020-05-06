using InventoryManagement.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using ShoeShop.Data;
using ShoeShop.Models;
using ShoeShop.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repositories
{
    public class ProductsRepository : Repository<Product>, IProductRepository
    {
        private readonly ShoeShopContext _context;

        public ProductsRepository(ShoeShopContext context): base(context)
        {
            _context = context;
        }
    }
}
