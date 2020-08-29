using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    public class SaleAndPaymentMethodProfile : Profile
    {
        public SaleAndPaymentMethodProfile()
        {
            CreateMap<SalePaymentMethod, PaymentDetailsDto>()
                 .ForMember(q => q.Amount, opt => opt.MapFrom(s => s.Amount))
                 .ForMember(q => q.DefferedPaymentCount, opt => opt.MapFrom(s => s.DefferedPaymentCount))
                 .ForMember(q => q.PaymentName, opt => opt.MapFrom(s => s.PaymentMethod.PaymentName))
                 .ForMember(q => q.PaymentType, opt => opt.MapFrom(s => s.PaymentMethod.PaymentType))
                 .ForMember(q => q.Receipt, opt => opt.MapFrom(s => s.Receipt));


        }
    }
}
