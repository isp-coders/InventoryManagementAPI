using AutoMapper;
using InventoryManagement.Application.Services.SalesService.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Utils.AutoMapper.Profiles
{
    class SaleProductProfile: Profile
    {
        public SaleProductProfile()
        {
            CreateMap<SaleProduct, SaleProductDto>();
        }
    }
}
