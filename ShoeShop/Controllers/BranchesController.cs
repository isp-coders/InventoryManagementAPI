using InventoryManagement.Application.Services.BranchesService;
using InventoryManagement.Application.Services.BranchesService.DTOs;
using InventoryManagement.Utils.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sample;
using System.Threading.Tasks;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService _branchesService;
        public BranchesController(IBranchService branchesRepository)
        {
            _branchesService = branchesRepository;
        }

        // GET: api/Branches
        [HttpGet("Get")]
        public ActionResult GetBranches(DataSourceLoadOptions loadOptions)
        {
            var result = _branchesService.GetEntities(loadOptions);
            return Ok(result);
        }

        // PUT: api/Branches/5
        [HttpPost("Update")]
        public async Task<IActionResult> PutColor([FromForm] int key, [FromForm] string values)
        {
            var puttedBranch = await _branchesService.PutEntity(key, values);

            return Ok(puttedBranch);
        }

        // POST: api/Branches
        [HttpPost("Insert")]
        public async Task<ActionResult<BranchDto>> PostBranch([FromForm] string values)
        {
            BranchDto Entity = new BranchDto();
            JsonConvert.PopulateObject(values, Entity);
            await _branchesService.PostEntity(Entity);
            return Ok();
        }

        // DELETE: api/Branches/5
        [HttpPost("Delete")]
        public async Task<ActionResult<BranchDto>> DeleteColor([FromForm] int Key)
        {
            var branch = await _branchesService.DeleteEntity(Key);
            if (branch == null)
            {
                return NotFound(new UIResponse() { IsError = true, Message = "STOCK_MODULE.MASTER_DATA.NOT_FOUND" });
            }

            return Ok(new UIResponse() { Entity = branch });
        }
    }
}
