using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeShop.Models;
using ShoeShop.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchesRepository _branchesRepository;
        public BranchesController(IBranchesRepository branchesRepository)
        {
            _branchesRepository = branchesRepository;
        }

        // GET: api/Branches
        [HttpGet]
        public async Task<ActionResult> GetBranches()
        {
            var result = await _branchesRepository.GetBranches();
            return Ok(result);
        }

        // PUT: api/Branches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(int id, Branch color)
        {
            if (id != color.Id)
            {
                return BadRequest();
            }
            var result = new Exception();
            try
            {
                result = await _branchesRepository.PutBranch(id, color);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (result is KeyNotFoundException)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Branches
        [HttpPost]
        public async Task<ActionResult<Branch>> PostColors(Branch[] color)
        {
            await _branchesRepository.PostBranches(color);
            return Ok();
        }

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Branch>> DeleteColor(int id)
        {
            var color = await _branchesRepository.DeleteBranch(id);
            if (color is KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
