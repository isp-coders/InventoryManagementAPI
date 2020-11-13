using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Utils.Response;
using Newtonsoft.Json;
using Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services
{
    public class Service<T, TDto> : IService<T, TDto>
    {

        private readonly IRepository<T> _Repository;
        private readonly IMapper mapper;
        public Service(IRepository<T> Repository, IMapper mapper)
        {
            _Repository = Repository;
            this.mapper = mapper;
        }

        public async Task<TDto> DeleteEntity(int id)
        {
            var DeleteEntity = await _Repository.DeleteEntity(id);
            await _Repository.SaveChangesAsync();
            return mapper.Map<TDto>(DeleteEntity);
        }

        public UIResponse GetEntities(DataSourceLoadOptions loadOptions, params Expression<Func<T, object>>[] includes)
        {
            var loadResult = DataSourceLoader.Load(_Repository.GetEntities(includes), loadOptions);
            if (loadResult.data.OfType<T>().Any())
            {
                loadResult.data = mapper.Map<List<TDto>>(loadResult.data.Cast<T>().ToList());
            }
            UIResponse response = mapper.Map<UIResponse>(loadResult);
            return response;
        }

        public async Task<TDto> GetEntity(int Id)
        {
            return mapper.Map<TDto>(await _Repository.FindEntity(Id));
        }

        public async Task<TDto> PostEntity(TDto EntityDto)
        {
            T entity = mapper.Map<T>(EntityDto);
            var postedEntity = await _Repository.PostEntity(entity);
            await _Repository.SaveChangesAsync();
            return mapper.Map<TDto>(postedEntity);
        }

        public async Task<TDto[]> PostEntities(string values)
        {
            List<T> Entities = new List<T>();
            JsonConvert.PopulateObject(values, Entities);
            var postedEntities = await _Repository.PostEntities(Entities);
            await _Repository.SaveChangesAsync();
            return mapper.Map<TDto[]>(postedEntities);
        }

        public async Task<TDto> PutEntity(int id, string values)
        {
            var puttedEntity = await _Repository.PutEntity(id, values);
            await _Repository.SaveChangesAsync();
            return mapper.Map<TDto>(puttedEntity);
        }

        public async Task<TDto> FindEntity(int Id)
        {
            return mapper.Map<TDto>(await _Repository.FindEntity(Id));
        }
    }
}
