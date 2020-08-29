using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    public class SoledProductDetailsProfile : Profile
    {
        public SoledProductDetailsProfile()
        {
            CreateMap<SaleDetailsAndProduct, SoledProductDetailsDto>()
    .ForMember(q => q.BranchName, opt => opt.MapFrom(s => s.Product.Branch.Name))
    .ForMember(q => q.ColorName, opt => opt.MapFrom(s => s.Product.Color.ColorName))
    .ForMember(q => q.Gender, opt => opt.MapFrom(s => s.Product.Gender))
    .ForMember(q => q.ProductCode, opt => opt.MapFrom(s => s.Product.ProductCode))
    .ForMember(q => q.ProductFullCode, opt => opt.MapFrom(s => s.Product.ProductFullCode))
    .ForMember(q => q.ProductName, opt => opt.MapFrom(s => s.Product.ProductName))
    .ForMember(q => q.ProductYear, opt => opt.MapFrom(s => s.Product.ProductYear))
    .ForMember(q => q.Size, opt => opt.MapFrom(s => s.Product.Size))
    .ForMember(q => q.ProductCount, opt => opt.MapFrom(s => s.ProductCount));
        }
    }
}
