using AutoMapper;
using InventoryManagement.Application.Services.BranchesService.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.BranchesService
{
    public class BranchService : Service<Branch,BranchDto>, IBranchService
    {
        private readonly IRepository<Branch> _BranchRepository;
        private readonly IMapper _mapper;
        public BranchService(IRepository<Branch> BranchRepository, IMapper _mapper) : base(BranchRepository, _mapper)
        {
            _BranchRepository = BranchRepository;
        }
    }
}
