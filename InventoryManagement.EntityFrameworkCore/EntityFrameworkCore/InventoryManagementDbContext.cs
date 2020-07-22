using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Data
{
    public class InventoryManagementDbContext : DbContext
    {
        public InventoryManagementDbContext(DbContextOptions<InventoryManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
    .HasKey(bc => new { bc.RoleId, bc.UserId });
            modelBuilder.Entity<UserRole>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(bc => bc.Role)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(bc => bc.RoleId);


            modelBuilder.Entity<SalePaymentMethod>()
.HasKey(bc => new { bc.SaleId, bc.PaymentMethodId });
            modelBuilder.Entity<SalePaymentMethod>()
                .HasOne(bc => bc.Sale)
                .WithMany(b => b.SalePaymentMethods)
                .HasForeignKey(bc => bc.SaleId);
            modelBuilder.Entity<SalePaymentMethod>()
                .HasOne(bc => bc.PaymentMethod)
                .WithMany(c => c.SalePaymentMethods)
                .HasForeignKey(bc => bc.PaymentMethodId);


            modelBuilder.Entity<SaleProduct>()
.HasKey(bc => new { bc.SaleId, bc.ProductId });
            modelBuilder.Entity<SaleProduct>()
                .HasOne(bc => bc.Sale)
                .WithMany(b => b.SaleProducts)
                .HasForeignKey(bc => bc.SaleId);
            modelBuilder.Entity<SaleProduct>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.SaleProducts)
                .HasForeignKey(bc => bc.ProductId);
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<SalesDetails> Sales { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<CustomerInfo> CustomerInfo { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoleRelation { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<SalePaymentMethod> SalePaymentMethodsRelation { get; set; }
    }
}
