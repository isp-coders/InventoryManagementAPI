using AutoMapper;
using ShoeShop.DTOs;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.AutoMapper.Profiles
{
    public class ProductProductViewProfile : Profile
    {
        public ProductProductViewProfile()
        {
            CreateMap<Product, ProductViewDto>()
                 .ForMember(q => q.Id, opt => opt.MapFrom(s => s.Id))
                 .ForMember(q => q.ProductName, opt => opt.MapFrom(s => s.ProductName))
                 .ForMember(q => q.ProductFullCode, opt => opt.MapFrom(s => s.ProductFullCode))
                 .ForMember(q => q.ProductCode, opt => opt.MapFrom(s => s.ProductCode))
                 .ForMember(q => q.Gender, opt => opt.MapFrom(s => s.Gender))
                 .ForMember(q => q.Price, opt => opt.MapFrom(s => s.Price))
                 .ForMember(q => q.ProductYear, opt => opt.MapFrom(s => s.ProductYear.ToString()))
                 .ForMember(q => q.Size, opt => opt.MapFrom(s => s.Size))
                 .ForMember(q => q.ColorId, opt => opt.MapFrom(s => s.Color.Id))
                 .ForMember(q => q.BranchName, opt => opt.MapFrom(s => s.Branch.Name))
                 .ForMember(q => q.BranchId, opt => opt.MapFrom(s => s.BranchId))
                 .ForMember(q => q.Count, opt => opt.MapFrom(s => s.Count))
                 .ForMember(q => q.SellingPrice, opt => opt.AllowNull())
                 .ForMember(q => q.Branch, opt => opt.MapFrom(s => s.Branch))
                 .ForMember(q => q.Date, opt => opt.MapFrom(s => s.SaleProducts.Select(se => se.Sale.Date).ToString()));


        }
    }
}
