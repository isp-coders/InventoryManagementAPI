using InventoryManagement.Application.Services.ProductTypeService;
using InventoryManagement.Application.Services.ProductTypeService.DTOs;
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
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;
        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }


        [HttpGet("Get")]
        public ActionResult GetProductTypes(DataSourceLoadOptions loadOptions)
        {
            var result = _productTypeService.GetEntities(loadOptions);
            return Ok(result);
        }


        [HttpPost("Update/{id}")]
        public async Task<IActionResult> PutProductType([FromForm] int key, [FromForm] string values)
        {
            var puttedProductType = await _productTypeService.PutEntity(key, values);

            return Ok(puttedProductType);
        }


        [HttpPost("Insert")]
        public async Task<ActionResult<ProductTypeDto>> PostProductType([FromForm] string values)
        {
            ProductTypeDto Entity = new ProductTypeDto();
            JsonConvert.PopulateObject(values, Entity);
            await _productTypeService.PostEntity(Entity);
            return Ok();
        }


        [HttpPost("Delete")]
        public async Task<ActionResult<ProductTypeDto>> DeleteProductType([FromForm] int Key)
        {
            var productType = await _productTypeService.DeleteEntity(Key);
            if (productType == null)
            {
                return NotFound(new UIResponse() { IsError = true, Message = "STOCK_MODULE.MASTER_DATA.NOT_FOUND" });
            }

            return Ok(new UIResponse() { Entity = productType });
        }
    }
}
