using InventoryManagement.Application.Services.ProductPropertyService;
using InventoryManagement.Application.Services.ProductPropertyService.DTOs;
using InventoryManagement.Utils.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sample;
using System.Threading.Tasks;

namespace InventoryManagement.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductPropertyController : ControllerBase
    {
        private readonly IProductPropertyService _productPropertyService;
        public ProductPropertyController(IProductPropertyService productPropertyService)
        {
            _productPropertyService = productPropertyService;
        }


        [HttpGet("Get")]
        public ActionResult GetProductTypes(DataSourceLoadOptions loadOptions)
        {
            var result = _productPropertyService.GetEntities(loadOptions);
            return Ok(result);
        }


        [HttpPost("Update/{id}")]
        public async Task<IActionResult> PutProductType([FromForm] int key, [FromForm] string values)
        {
            var puttedProductType = await _productPropertyService.PutEntity(key, values);

            return Ok(puttedProductType);
        }


        [HttpPost("Insert")]
        public async Task<ActionResult<ProductPropertyDto>> PostProductType([FromForm] string values)
        {
            ProductPropertyDto Entity = new ProductPropertyDto();
            JsonConvert.PopulateObject(values, Entity);
            await _productPropertyService.PostEntity(Entity);
            return Ok();
        }


        [HttpPost("Delete")]
        public async Task<ActionResult<ProductPropertyDto>> DeleteProductType([FromForm] int Key)
        {
            var productType = await _productPropertyService.DeleteEntity(Key);
            if (productType == null)
            {
                return NotFound(new UIResponse() { IsError = true, Message = "STOCK_MODULE.MASTER_DATA.NOT_FOUND" });
            }

            return Ok(new UIResponse() { Entity = productType });
        }
    }
}
