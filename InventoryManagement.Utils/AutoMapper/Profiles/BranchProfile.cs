using AutoMapper;
using InventoryManagement.Application.Services.BranchesService.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Interface.AutoMapper.Profiles
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch, BranchDto>();
        }
    }
}
