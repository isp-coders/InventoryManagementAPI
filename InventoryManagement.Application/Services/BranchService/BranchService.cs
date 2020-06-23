using InventoryManagement.Application.Services.BranchesService.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.BranchesService
{
    public class BranchService : Service<Branch>, IBranchService
    {
        private readonly IRepository<Branch> _BranchRepository;
        public BranchService(IRepository<Branch> BranchRepository) : base(BranchRepository)
        {
            _BranchRepository = BranchRepository;
        }
    }
}
