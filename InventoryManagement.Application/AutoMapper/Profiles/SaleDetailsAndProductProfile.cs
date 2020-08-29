using AutoMapper;
using InventoryManagement.Application.Services.SalesService.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    class SaleDetailsAndProductProfile : Profile
    {
        public SaleDetailsAndProductProfile()
        {
            CreateMap<SaleDetailsAndProduct, SaleDetailsAndProductDto>();
        }
    }
}
