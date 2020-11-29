using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using InventoryManagement.Utils.Response;
using Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services
{
    public interface IService<T, TDto>
    {
        Task<TDto> GetEntity(int Id);
        UIResponse GetEntities(DataSourceLoadOptions loadOptions, string includes = "");
        Task<TDto> PutEntity(int id, string values);
        Task<TDto[]> PostEntities(string values);
        Task<TDto> PostEntity(TDto entityDto);
        Task<TDto> DeleteEntity(int id);
        Task<TDto> FindEntity(int id);
    }
}
