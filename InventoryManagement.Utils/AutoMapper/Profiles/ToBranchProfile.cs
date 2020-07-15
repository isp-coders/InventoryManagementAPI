using AutoMapper;
using InventoryManagement.Application.Services.BranchesService.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Utils.AutoMapper.Profiles
{
    class ToBranchProfile : Profile
    {
        public ToBranchProfile()
        {
            CreateMap<BranchDto, Branch>();
        }
    }
}
