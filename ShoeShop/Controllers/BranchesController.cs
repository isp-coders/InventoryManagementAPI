using InventoryManagement.Application.Services.BranchesService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;
using InventoryManagement.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Application.Services.BranchesService.DTOs;
using DevExtreme.AspNet.Data;
using Sample;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService _branchesService;
        public BranchesController(IBranchService branchesRepository)
        {
            _branchesService = branchesRepository;
        }

        // GET: api/Branches
        [HttpGet]
        public ActionResult GetBranches(DataSourceLoadOptions loadOptions)
        {
            var result = _branchesService.GetEntities(loadOptions);
            return Ok(result);
        }

        // PUT: api/Branches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(int id, BranchDto branch)
        {
            if (id != branch.Id)
            {
                return BadRequest();
            }

            var puttedBranch = await _branchesService.PutEntity(id, branch);

            return Ok(puttedBranch);
        }

        // POST: api/Branches
        [HttpPost]
        public async Task<ActionResult<Branch>> PostColors(BranchDto[] color)
        {
            await _branchesService.PostEntities(color);
            return Ok();
        }

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Branch>> DeleteColor(int id)
        {
            var color = await _branchesService.DeleteEntity(id);
            if (color == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
