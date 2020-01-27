using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeShop.Data;
using ShoeShop.Models;
using ShoeShop.Repositories;

namespace ShoeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorsRepository _colorsRepository;

        public ColorsController(IColorsRepository colorsRepository)
        {
            _colorsRepository = colorsRepository;
        }

        // GET: api/Colors
        [HttpGet]
        public async Task<ActionResult> GetColors()
        {
            var result = await _colorsRepository.GetColors();
            return Ok(result);
        }

        // GET: api/Colors/5
        [HttpGet("{id}")]
        public ActionResult<Color> GetColor(int id)
        {
            var color = _colorsRepository.GetColor(id);

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
            var result = new Exception();
            try
            {
                result = await _colorsRepository.PutColor(id, color);
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

        // POST: api/Colors
        [HttpPost]
        public async Task<ActionResult<Color>> PostColor(Color color)
        {
            await _colorsRepository.PostColor(color);
            return Ok();
        }

        // DELETE: api/Colors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Color>> DeleteColor(int id)
        {
            var color = await _colorsRepository.DeleteColor(id);
            if (color is KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
