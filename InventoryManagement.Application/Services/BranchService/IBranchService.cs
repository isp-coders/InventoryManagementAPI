using InventoryManagement.Application.Services.BranchesService.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.BranchesService
{
    public interface IBranchService : IService<Branch,BranchDto>
    {
    }
}
