using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Utils.AutoMapper.Profiles
{
    class UserRoleProfile: Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRole, UserRoleDto>();
        }
    }
}
