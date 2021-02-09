using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.IRepositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetQuery(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        Task<T> PutEntity(int id, string values);
        T PutEntity(T Entity);
        List<T> PutEntities(List<T> Entities);
        Task<T> PostEntity(T Entity);
        Task<List<T>> PostEntities(List<T> Entities);
        Task<T> DeleteEntity(int id);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        ValueTask<T> FindEntity(int id);
        IQueryable<T> GetEntities(params Expression<Func<T, object>>[] includes);
        Task SaveChangesAsync();
        void SaveChanges();

    }
}
