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
    .ForMember(q => q.ProductBarcode, opt => opt.MapFrom(s => s.Product.ProductBarcode))
    .ForMember(q => q.ProductName, opt => opt.MapFrom(s => s.Product.ProductName))
    .ForMember(q => q.ProductYear, opt => opt.MapFrom(s => s.Product.ProductYear))
    .ForMember(q => q.Size, opt => opt.MapFrom(s => s.Product.Size))
    .ForMember(q => q.ProductCount, opt => opt.MapFrom(s => s.ProductCount))
    .ForMember(q => q.ExpirationDate, opt => opt.MapFrom(s => s.Product.ExpirationDate))
    .ForMember(q => q.Description, opt => opt.MapFrom(s => s.Product.Description))
    .ForMember(q => q.Price, opt => opt.MapFrom(s => s.Price))
    .ForMember(q => q.Operations, opt => opt.MapFrom(s => s.Operations))
    ;
        }
    }
}
