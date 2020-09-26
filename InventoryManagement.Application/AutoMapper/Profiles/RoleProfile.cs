using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>()
                .ForMember(q => q.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(q => q.RoleAndRolePermessions, opt => opt.MapFrom(s => s.RoleAndRolePermessions))
                .ForMember(q => q.RoleName, opt => opt.MapFrom(s => s.RoleName))
                .ForMember(q => q.RolePermessionsIds, opt => opt.MapFrom(s => s.RoleAndRolePermessions.Select(se=> se.RolePermession.Id)))
                .ForMember(q => q.Users, opt => opt.MapFrom(s => s.Users));
        }
    }
}
