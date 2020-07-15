using AutoMapper;
using InventoryManagement.Application.Services.ColorService.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.ColorService
{
    public class ColorService : Service<Color, ColorDto>, IColorService
    {
        private readonly IRepository<Color> _ColorRepository;
        private readonly IMapper _mapper;
        public ColorService(IRepository<Color> ColorRepository, IMapper _mapper) : base(ColorRepository, _mapper)
        {
            _ColorRepository = ColorRepository;
        }
    }
}
