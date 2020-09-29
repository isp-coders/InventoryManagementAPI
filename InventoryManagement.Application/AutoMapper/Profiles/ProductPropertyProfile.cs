using AutoMapper;
using InventoryManagement.Application.Services.ProductPropertyService.DTOs;
using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    public class ProductPropertyProfile : Profile
    {
        public ProductPropertyProfile()
        {
            CreateMap<ProductProperty, ProductPropertyDto>();
        }
    }
}
