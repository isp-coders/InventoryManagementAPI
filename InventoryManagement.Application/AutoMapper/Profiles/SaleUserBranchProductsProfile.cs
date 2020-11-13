using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    public class SaleUserBranchProductsProfile : Profile
    {
        public SaleUserBranchProductsProfile()
        {
            CreateMap<SalesDetails, SaleUserBranchProductsDTO>()
                .ForMember(q => q.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(q => q.Date, opt => opt.MapFrom(s => s.Date))
                .ForMember(q => q.Branch, opt => opt.MapFrom(s => s.Branch))
                .ForMember(q => q.Total, opt => opt.MapFrom(s => s.Total))
                .ForMember(q => q.User, opt => opt.MapFrom(s => s.User))
                .ForMember(q => q.SoledProductDetails, opt => opt.MapFrom(s => s.SaleDetailsAndProducts))
                .ForMember(q => q.PaymentDetails, opt => opt.MapFrom(s => s.SalePaymentMethods))
                .ForMember(q => q.RefundAmount, opt => opt.MapFrom(s => s.RefundAmount))
                ;
        }
    }
}
