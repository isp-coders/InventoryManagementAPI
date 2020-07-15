using AutoMapper;
using InventoryManagement.Application.Services.PaymentMethodService.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Utils.AutoMapper.Profiles
{
    class ToPaymentMethod : Profile
    {
        public ToPaymentMethod()
        {
            CreateMap<PaymentMethodDto, PaymentMethod>();
        }
    }
}
