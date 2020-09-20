using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using InventoryManagement.Core.IRepositories;
using Newtonsoft.Json;
using Sample;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return mapper.Map<TDto>(await _Repository.DeleteEntity(id));
        }

        public LoadResult GetEntities(DataSourceLoadOptions loadOptions)
        {
            var loadResult = DataSourceLoader.Load(_Repository.GetEntities(), loadOptions);
            loadResult.data = mapper.Map<IEnumerable<TDto>>(loadResult.data.Cast<T>().ToList());
            return loadResult;
        }

        public async Task<TDto> GetEntity(int Id)
        {
            return mapper.Map<TDto>(await _Repository.FindEntity(Id));
        }

        public async Task<TDto> PostEntity(TDto EntityDto)
        {
            T entity = mapper.Map<T>(EntityDto);
            return mapper.Map<TDto>(await _Repository.PostEntity(entity));
        }

        public async Task<TDto[]> PostEntities(string values)
        {
            List<T> Entities = new List<T>();
            JsonConvert.PopulateObject(values, Entities);
            //T[] EntitiesDto = mapper.Map<T[]>(entitiesDto);
            return mapper.Map<TDto[]>(await _Repository.PostEntities(Entities));
        }

        public async Task<TDto> PutEntity(int id, string values)
        {
            //T entity = mapper.Map<T>(entityDto);
            return mapper.Map<TDto>(await _Repository.PutEntity(id, values));
        }

        public async Task<TDto> FindEntity(int Id)
        {
            return mapper.Map<TDto>(await _Repository.FindEntity(Id));
        }
    }
}
