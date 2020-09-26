using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    public class RoleAndRolePermessionDtoProfile : Profile
    {
        public RoleAndRolePermessionDtoProfile()
        {
            CreateMap<RoleAndRolePermession, RoleAndRolePermessionDto>();
        }
    }
}
