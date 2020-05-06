using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services
{
    public interface IService<T>
    {
        Task<T> GetEntity(int Id);
        List<T> GetEntities();
        Task<T> PutEntity(int id, T entity);
        Task<T[]> PostEntities(T[] entities);
        Task<T> PostEntity(T entity);
        Task<T> DeleteEntity(int id);
        Task<T> FindEntity(int id);
    }
}
