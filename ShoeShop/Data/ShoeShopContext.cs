using Microsoft.EntityFrameworkCore;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Data
{
    public class ShoeShopContext : DbContext
    {
        public ShoeShopContext(DbContextOptions<ShoeShopContext> options): base(options)
        {
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
