using InventoryManagement.Application.Services.ColorService;
using InventoryManagement.Application.Services.ColorService.DTOs;
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
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        // GET: api/Colors
        [HttpGet("Get")]
        public ActionResult GetColors(DataSourceLoadOptions loadOptions)
        {
            var result = _colorService.GetEntities(loadOptions);
            return Ok(result);
        }

        // GET: api/Colors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ColorDto>> GetColor(int id)
        {
            var color = await _colorService.FindEntity(id);

            if (color == null)
            {
                return NotFound();
            }

            return Ok(color);
        }

        // PUT: api/Colors/5
        [HttpPost("Update")]
        public async Task<IActionResult> PutColor([FromForm] int key, [FromForm] string values)
        {
            var result = await _colorService.PutEntity(key, values);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);
        }


        [HttpPost("Insert")]
        public async Task<ActionResult> PostColor([FromForm] string values)
        {
            ColorDto Entity = new ColorDto();
            JsonConvert.PopulateObject(values, Entity);
            await _colorService.PostEntity(Entity);
            return Ok();
        }

        // DELETE: api/Colors/5
        [HttpPost("Delete")]
        public async Task<ActionResult<ColorDto>> DeleteColor( [FromForm] int Key)
        {
            var color = await _colorService.DeleteEntity(Key);
            if (color == null)
            {
                return NotFound(new UIResponse() { IsError = true, Message = "STOCK_MODULE.MASTER_DATA.NOT_FOUND" });
            }

            return Ok(new UIResponse() { Entity = color });
        }
    }
}
