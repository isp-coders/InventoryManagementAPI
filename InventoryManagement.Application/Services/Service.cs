using InventoryManagement.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services
{
    public class Service<T> : IService<T>
    {

        private readonly IRepository<T> _Repository;
        public Service(IRepository<T> Repository)
        {
            _Repository = Repository;
        }

        public async Task<T> DeleteEntity(int id)
        {
            return await _Repository.DeleteEntity(id);
        }

        public List<T> GetEntities()
        {
            return _Repository.GetEntities().ToList();
        }

        public async Task<T> GetEntity(int Id)
        {
            return await _Repository.FindEntity(Id);
        }

        public async Task<T> PostEntity(T Entity)
        {
            return await _Repository.PostEntity(Entity);
        }

        public async Task<T[]> PostEntities(T[] entities)
        {
            return await _Repository.PostEntities(entities);
        }

        public async Task<T> PutEntity(int id, T entity)
        {
            return await _Repository.PutEntity(id, entity);
        }

        public async Task<T> FindEntity(int Id)
        {
            return await _Repository.FindEntity(Id);
        }
    }
}
