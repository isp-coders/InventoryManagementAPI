using InventoryManagement.Core.IRepositories;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.ColorService
{
    public class ColorService : Service<Color>, IColorService
    {
        private readonly IRepository<Color> _ColorRepository;
        public ColorService(IRepository<Color> ColorRepository) : base(ColorRepository)
        {
            _ColorRepository = ColorRepository;
        }
    }
}
