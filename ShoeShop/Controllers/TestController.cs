using InventoryManagement.Application.Services.BranchesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly IBranchService _branchesService;
        public TestController(IBranchService branchesRepository)
        {
            _branchesService = branchesRepository;
        }
    }
}
