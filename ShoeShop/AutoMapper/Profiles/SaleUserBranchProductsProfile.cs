using AutoMapper;
using ShoeShop.DTOs;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.AutoMapper.Profiles
{
    public class SaleUserBranchProductsProfile : Profile
    {
        public SaleUserBranchProductsProfile()
        {
            CreateMap<SalesDetails, SaleUserBranchProductsDTO>()
                .ForMember(q => q.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(q => q.Date, opt => opt.MapFrom(s => s.Date))
                .ForMember(q => q.BranchName, opt => opt.MapFrom(s => s.Branch.Name))
                .ForMember(q => q.Total, opt => opt.MapFrom(s => s.Total))
                .ForMember(q => q.UserCode, opt => opt.MapFrom(s => s.User.UserCode))
                .ForMember(q => q.SoledProductDetails, opt => opt.MapFrom(s => s.SaleProducts))
                .ForMember(q=> q.PaymentDetails, opt => opt.MapFrom(s => s.SalePaymentMethods));
        }
    }
}
