using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    public class RolePermessionProfile : Profile
    {
        public RolePermessionProfile()
        {
            CreateMap<RolePermession, RolePermessionDto>();
        }
    }
}
