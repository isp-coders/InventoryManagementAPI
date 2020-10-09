using AutoMapper;
using InventoryManagement.Application.Services.ProductTypeService.DTOs;
using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    public class ProductTypeProfile : Profile
    {
        public ProductTypeProfile()
        {
            CreateMap<ProductType, ProductTypeDto>()
                 .ForMember(q => q.Id, opt => opt.MapFrom(s => s.Id))
                 .ForMember(q => q.Name, opt => opt.MapFrom(s => s.Name))
                 .ForMember(q => q.Products, opt => opt.MapFrom(s => s.Products))
                 .ForMember(q => q.ProductTypeAndProperties, opt => opt.MapFrom(s => s.ProductTypeAndProperties))
                 .ForMember(q => q.ProductPropertyIds, opt => opt.MapFrom(s => s.ProductTypeAndProperties.Select(se => se.ProductPropertyId)))
                 .ForMember(q => q.ProductProperties, opt => opt.MapFrom(s => s.ProductTypeAndProperties.Select(se => se.ProductProperty)))
                 ;
        }
    }
}
