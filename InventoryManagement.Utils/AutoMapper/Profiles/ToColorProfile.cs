using AutoMapper;
using InventoryManagement.Application.Services.ColorService.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Utils.AutoMapper.Profiles
{
    public class ToColorProfile : Profile
    {
        public ToColorProfile()
        {
            CreateMap<ColorDto, Color>();
        }
    }
}
