using AutoMapper;
using InventoryManagement.Application.Services.ProductService.DTOs;
using InventoryManagement.Models;


namespace InventoryManagement.Utils.AutoMapper.Profiles
{
    class ToProductProfile : Profile
    {
        public ToProductProfile()
        {
            CreateMap<ProductDto, Product>();
                //.ForMember(q => q.Color, opt => opt.Ignore())
                //.ForMember(q => q.Branch, opt => opt.Ignore())
                //.ForMember(q => q.SaleProducts, opt => opt.Ignore());
        }
    }
}
