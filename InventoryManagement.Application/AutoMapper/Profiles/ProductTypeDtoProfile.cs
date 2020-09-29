using AutoMapper;
using InventoryManagement.Application.Services.ProductTypeService.DTOs;
using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    public class ProductTypeDtoProfile : Profile
    {
        public ProductTypeDtoProfile()
        {
            CreateMap<ProductTypeDto, ProductType>();
        }
    }
}
