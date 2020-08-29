using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.RoleService
{
    public class RoleService : Service<Role, RoleDto>, IRoleService
    {
        private readonly IRepository<Role> RoleRepository;
        private readonly IMapper _mapper;
        public RoleService(IRepository<Role> RoleRepository, IMapper _mapper) : base(RoleRepository, _mapper)
        {
            this.RoleRepository = RoleRepository;
        }

    }
}
