using InventoryManagement.Application.Services;
using InventoryManagement.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Interface.Controllers
{
    public class BaseController<T, TDto> : ControllerBase where TDto : class, new()
    {
        private readonly IService<T, TDto> _service;

        public BaseController(IService<T, TDto> service)
        {
            _service = service;
        }

        [HttpGet("Get")]
        public ActionResult Get(DataSourceLoadOptions loadOptions)
        {
            var result = _service.GetEntities(loadOptions);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Put([FromForm] int key, [FromForm] string values)
        {
            var puttedBranch = await _service.PutEntity(key, values);

            return Ok(puttedBranch);
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<TDto>> Post([FromForm] string values)
        {
            TDto Entity = new TDto();
            JsonConvert.PopulateObject(values, Entity);
            await _service.PostEntity(Entity);
            return Ok();
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<TDto>> Delete([FromForm] int Key)
        {
            var branch = await _service.DeleteEntity(Key);
            if (branch == null)
            {
                return NotFound(new UIResponse() { IsError = true, Message = "STOCK_MODULE.MASTER_DATA.NOT_FOUND" });
            }

            return Ok(new UIResponse() { Entity = branch });
        }
    }
}
