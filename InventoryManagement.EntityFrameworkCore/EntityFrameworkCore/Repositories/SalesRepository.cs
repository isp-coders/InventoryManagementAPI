using InventoryManagement.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using InventoryManagement.Data;
using InventoryManagement.Models;
using InventoryManagement.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InventoryManagement.Repositories
{
    public class SalesRepository : Repository<SalesDetails>, ISalesRepository
    {
        private readonly InventoryManagementDbContext _context;

        public SalesRepository(InventoryManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<SalesDetails> GetSaleDetailsWithSubProperties()
        {
            return _context.Sales.Include(inc => inc.User).Include(inc => inc.Branch).Include(th => th.SaleDetailsAndProducts).ThenInclude(th => th.Product).Include(th => th.SalePaymentMethods).ThenInclude(th => th.PaymentMethod).AsQueryable();
        }
    }
}
