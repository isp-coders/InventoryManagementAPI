using AutoMapper;
using InventoryManagement.Application.Services.ColorService.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorDto>();
        }
    }
}
