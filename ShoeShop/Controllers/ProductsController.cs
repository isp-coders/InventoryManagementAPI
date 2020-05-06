using InventoryManagement.Application.Services.ProductService;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productsService)
        {
            _productService = productsService;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult GetProducts()
        {
            var result = _productService.GetEntities();
            return Ok(result);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            var result = await _productService.PutEntity(id, product);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProducts(Product[] products)
        {
            await _productService.PostEntities(products);
            return Ok();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _productService.DeleteEntity(id);
            if (product is null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
