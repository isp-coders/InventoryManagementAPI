using InventoryManagement.Application.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;
using InventoryManagement.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Application.Services.ProductService.DTOs;
using Sample;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productsService)
        {
            _productService = productsService;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult GetProducts(DataSourceLoadOptions loadOptions)
        {
            var result = _productService.GetEntities(loadOptions);
            return Ok(result);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromForm] int key, [FromForm] string values)
        {
            var result = await _productService.PutEntity(key, values);

            if (result is null)
            {
                return NotFound();
            }

            return Ok();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProducts([FromForm] string values)
        {
            await _productService.PostEntities(values);
            return Ok();
        }

        // DELETE: api/Products/5
        [HttpDelete]
        public async Task<ActionResult<Product>> DeleteProduct([FromForm] int key)
        {
            var product = await _productService.DeleteEntity(key);
            if (product is null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
