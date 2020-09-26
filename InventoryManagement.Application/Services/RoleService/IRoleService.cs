using DevExtreme.AspNet.Data.ResponseModel;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Services.RoleService.DTOs;
using InventoryManagement.Models;
using Sample;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.RoleService
{
    public interface IRoleService : IService<Role, RoleDto>
    {
        LoadResult GetRoleAuthorities(int RoleId, DataSourceLoadOptions loadOptions);
        Task SaveRolePermessions(RoleIdAndPermessions SaveRolePermessions);
    }
}
