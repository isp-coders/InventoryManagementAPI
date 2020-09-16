using InventoryManagement.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using InventoryManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InventoryManagement.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly InventoryManagementDbContext _context;


        /// <summary>
        /// Gets DbSet for given entity.
        /// </summary>
        public virtual DbSet<T> Table => _context.Set<T>();
        public Repository(InventoryManagementDbContext context)
        {
            _context = context;
        }
        public async Task<T> DeleteEntity(int id)
        {
            var Entity = await FindEntity(id);
            _context.Remove(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> queryable = Table;
            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }
            string[] array = includeProperties.Split(new char[1]
            {
        ','
            }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string navigationPropertyPath in array)
            {
                queryable = queryable.Include(navigationPropertyPath);
            }
            if (orderBy != null)
            {
                return orderBy(queryable);
            }
            return queryable;
        }

        public async ValueTask<T> FindEntity(int id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task<List<T>> PostEntities(List<T> Entities)
        {
            //List<T> Entities = new List<T>();
            //JsonConvert.PopulateObject(values, Entities);
            _context.AddRange(Entities);
            await _context.SaveChangesAsync();

            return Entities;
        }

        public async Task<T> PostEntity(T Entity)
        {
            _context.Add(Entity);
            await _context.SaveChangesAsync();

            return Entity;
        }

        public async Task<T> PutEntity(int id, string values)
        {
            var Entity = await _context.FindAsync<T>(id);
            JsonConvert.PopulateObject(values, Entity);
            _context.Entry(Entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Entity;
        }

        public IQueryable<T> GetIncludableEntities<EntityToInclude>(params Expression<Func<T, EntityToInclude>>[] navigationPropertyPaths)
        {
            IQueryable<T> queryableEntities = Table.AsQueryable();
            if (navigationPropertyPaths.Length > 0)
            {
                foreach (var propertyPath in navigationPropertyPaths)
                {
                    queryableEntities.Include(propertyPath);
                }
                return queryableEntities;
            }
            else
            {
                return Table.AsQueryable();
            }

        }

        public IQueryable<T> GetEntities()
        {
            return Table.AsQueryable();
        }
    }
}
