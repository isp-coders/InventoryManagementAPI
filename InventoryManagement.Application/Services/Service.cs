using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Core.Models;
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
            return DataSourceLoader.Load(mapper.ProjectTo<TDto>(_Repository.GetEntities()), loadOptions);
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

        public async Task<TDto[]> PostEntities(TDto[] entitiesDto)
        {
            T[] entities = mapper.Map<T[]>(entitiesDto);
            return mapper.Map<TDto[]>(await _Repository.PostEntities(entities));
        }

        public async Task<TDto> PutEntity(int id, TDto entityDto)
        {
            T entity = mapper.Map<T>(entityDto);
            return mapper.Map<TDto>(await _Repository.PutEntity(id, entity));
        }

        public async Task<TDto> FindEntity(int Id)
        {
            return mapper.Map<TDto>(await _Repository.FindEntity(Id));
        }
    }
}
