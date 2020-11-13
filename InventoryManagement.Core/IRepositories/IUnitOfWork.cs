using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Core.IRepositories
{
    public interface IUnitOfWork
    {

        void SaveChanges();

        void SaveChangesAsync();

        void BeginTransaction();

        void CommitTransaction();

        void RollBackTransaction();
    }
}
