using InventoryManagement.Core.IRepositories;
using InventoryManagement.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
            if (Entity != null)
            {
                if (_context.Entry(Entity).State == EntityState.Detached)
                {
                    Table.Attach(Entity);
                }
                Table.Remove(Entity);
            }
            else
            {
                return null;
            }
            return Entity;
        }

        public void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> queryable = Table;
            if (predicate != null)
            {
                IQueryable<T> entities = queryable.Where(predicate);
                Table.RemoveRange(entities);
            }
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
            return queryable.AsNoTracking();
        }

        public async ValueTask<T> FindEntity(int id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task<List<T>> PostEntities(List<T> Entities)
        {
            await _context.AddRangeAsync(Entities);
            return Entities;
        }

        public async Task<T> PostEntity(T Entity)
        {
            await _context.AddAsync(Entity);
            return Entity;
        }

        public T PutEntity(T Entity)
        {
            Table.Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;

            return Entity;
        }

        public async Task<T> PutEntity(int id, string values)
        {
            var Entity = await _context.FindAsync<T>(id);
            JsonConvert.PopulateObject(values, Entity);
            _context.Entry(Entity).State = EntityState.Modified;
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

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IQueryable<T> GetEntities(params Expression<Func<T, object>>[] includes)
        {
            var query = Table.AsQueryable();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    var IsIncludable = item.Body.GetType().GetProperty("Arguments") != null;
                    if (IsIncludable)
                    {
                        var Body = item.GetType().GetProperty("Body").GetValue(item, null);
                        IList Arguments = Body.GetType().GetProperty("Arguments").GetValue(Body, null) as IList;

                        List<string> childNavigations = new List<string>();
                        foreach (var argument in Arguments)
                        {

                            if (argument.GetType().GetProperty("Arguments") != null)
                            {
                                IList childList = argument.GetType().GetProperty("Arguments").GetValue(argument, null) as IList;


                                //var Include = query.Include(Arguments[0] as MemberExpression);
                                foreach (var property in childList)
                                {
                                    childNavigations.AddRange(property.ToString().Split(".").Skip(1));
                                    //var ii = property;
                                }
                            }
                            else
                            {
                                childNavigations.AddRange(argument.ToString().Split(".").Skip(1));
                            }
                        }
                        if (childNavigations.Count > 0)
                        {
                            query = query.Include(string.Join(".", childNavigations));
                        }
                        List<string> navigations = new List<string>();

                        //var Include = query.Include(Arguments[0] as MemberExpression);
                        //foreach (var property in Arguments)
                        //{
                        //    navigations.AddRange(property.ToString().Split(".").Skip(1));
                        //    //var ii = property;
                        //}

                        //string mainNavigation = navigations[0];
                        //query.Include(mainNavigation);
                        //navigations.RemoveAt(0);
                        //navigations.ForEach(nav =>
                        //{
                        //    query = query.Include(String.Concat(mainNavigation, ".", nav));
                        //});
                        //query = query.Include(string.Join(".", navigations));

                    }
                    else
                    {
                        //                        query = includes.Aggregate(query,
                        //(current, include) => current.Include(include));
                        query = query.Include(item);
                    }
                }
            }
            return query;
        }

    }
}
