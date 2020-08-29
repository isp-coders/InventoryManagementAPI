using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    public class ToCustomerInfo : Profile
    {
        public ToCustomerInfo()
        {
            CreateMap<CustomerInfoDto, CustomerInfo>();
        }

    }
}
