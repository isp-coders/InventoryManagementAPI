using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using InventoryManagement.Core.Models;
using Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services
{
    public interface IService<T,TDto>
    {
        Task<TDto> GetEntity(int Id);
        LoadResult GetEntities(DataSourceLoadOptions loadOptions);
        Task<TDto> PutEntity(int id, TDto entityDto);
        Task<TDto[]> PostEntities(TDto[] entitiesDto);
        Task<TDto> PostEntity(TDto entityDto);
        Task<TDto> DeleteEntity(int id);
        Task<TDto> FindEntity(int id);
    }
}
