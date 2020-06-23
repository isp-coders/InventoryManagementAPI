using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Application.Services.ColorService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Data;
using InventoryManagement.Models;
using InventoryManagement.Repositories;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        // GET: api/Colors
        [HttpGet]
        public ActionResult GetColors()
        {
            var result = _colorService.GetEntities();
            return Ok(result);
        }

        // GET: api/Colors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> GetColor(int id)
        {
            var color = await _colorService.FindEntity(id);

            if (color == null)
            {
                return NotFound();
            }

            return Ok(color);
        }

        // PUT: api/Colors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(int id, Color color)
        {
            if (id != color.Id)
            {
                return BadRequest();
            }
            var result = await _colorService.PutEntity(id, color);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);
        }

        // POST: api/Colors
        //[HttpPost]
        //public async Task<ActionResult<Color>> PostColor(Color color)
        //{
        //    await _colorsRepository.PostColor(color);
        //    return Ok();
        //}

        // POST: api/Colors
        [HttpPost]
        public async Task<ActionResult<Color>> PostColors(Color[] color)
        {
            await _colorService.PostEntities(color);
            return Ok();
        }

        // DELETE: api/Colors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Color>> DeleteColor(int id)
        {
            var color = await _colorService.DeleteEntity(id);
            if (color == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
