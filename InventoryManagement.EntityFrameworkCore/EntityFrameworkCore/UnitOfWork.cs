using InventoryManagement.Core.IRepositories;
using InventoryManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace InventoryManagement.EntityFrameworkCore.EntityFrameworkCore
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly InventoryManagementDbContext currentDBContext;

        public UnitOfWork(InventoryManagementDbContext context)
        {
            currentDBContext = context;
        }

        public IDbContextTransaction CurrentTransaction
        {
            get;
            set;
        }

        public void BeginTransaction()
        {
            CurrentTransaction = currentDBContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (CurrentTransaction != null)
            {
                CurrentTransaction.Commit();
            }
        }

        public void RollBackTransaction()
        {
            if (CurrentTransaction != null)
            {
                CurrentTransaction.Rollback();
            }
        }

        public async void SaveChangesAsync()
        {
            await currentDBContext.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            currentDBContext.SaveChanges();
        }
    }
}
