using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Services.RoleService.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Models;
using InventoryManagement.Utils.Response;
using Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.RoleService
{
    public class RoleService : Service<Role, RoleDto>, IRoleService
    {
        private readonly IRepository<Role> RoleRepository;
        private readonly IRepository<RolePermession> RolePermessionRepository;
        private readonly IRepository<RoleAndRolePermession> RoleAndPermessionRepository;
        private readonly IMapper _mapper;
        public RoleService(IRepository<Role> RoleRepository, IRepository<RolePermession> RolePermessionRepository, IRepository<RoleAndRolePermession> RoleAndPermessionRepository, IMapper _mapper) : base(RoleRepository, _mapper)
        {
            this.RoleRepository = RoleRepository;
            this.RolePermessionRepository = RolePermessionRepository;
            this.RoleAndPermessionRepository = RoleAndPermessionRepository;
        }


        public UIResponse GetRoleAuthorities(int RoleId, DataSourceLoadOptions loadOptions)
        {
            LoadResult loadResult = DataSourceLoader.Load(RoleRepository.GetEntities().Where(wh => wh.Id == RoleId), loadOptions);
            if (loadResult.data.OfType<Role>().Any())
            {
                loadResult.data = _mapper.Map<List<RoleDto>>(loadResult.data.Cast<Role>().ToList());
            }
            return _mapper.Map<UIResponse>(loadResult);
        }

        public async Task SaveRolePermessions(RoleIdAndPermessions SaveRolePermessions)
        {

            await RoleAndPermessionRepository.DeleteWhere(wh => wh.RoleId == SaveRolePermessions.RoleId);
            await RoleAndPermessionRepository.PostEntities(SaveRolePermessions.RolePermessions.Distinct()
                .Select(rolePermessionId => new RoleAndRolePermession
                {
                    RoleId = SaveRolePermessions.RoleId,
                    RolePermessionId = rolePermessionId
                }).ToList());

        }

    }
}
