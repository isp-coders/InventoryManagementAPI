using InventoryManagement.Application.Services.ColorService.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.ColorService
{
    public interface IColorService : IService<Color,ColorDto>
    {
    }
}
