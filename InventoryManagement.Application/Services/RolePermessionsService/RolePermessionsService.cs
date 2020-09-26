using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.RolePermessionsService
{
    public class RolePermessionsService : Service<RolePermession, RolePermessionDto>, IRolePermessionsService
    {
        private readonly IRepository<RolePermession> _RolePermessionRepository;
        private readonly IMapper _mapper;
        public RolePermessionsService(IRepository<RolePermession> _RolePermessionRepository, IMapper _mapper) : base(_RolePermessionRepository, _mapper)
        {
            this._RolePermessionRepository = _RolePermessionRepository;
            this._mapper = _mapper;
        }
    }
}
