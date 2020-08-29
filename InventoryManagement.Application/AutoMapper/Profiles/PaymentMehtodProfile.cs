using AutoMapper;
using InventoryManagement.Application.Services.PaymentMethodService.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    class PaymentMehtodProfile : Profile
    {
        public PaymentMehtodProfile()
        {
            CreateMap<PaymentMethod, PaymentMethodDto>();
        }
    }
}
