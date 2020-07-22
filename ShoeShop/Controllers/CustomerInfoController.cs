using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Services.CustomerInfoService;
using Microsoft.AspNetCore.Mvc;
using Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInfoController : ControllerBase
    {
        private readonly ICustomerInfoService customerInfo;

        public CustomerInfoController(ICustomerInfoService customerInfo)
        {
            this.customerInfo = customerInfo;
        }


        [HttpGet]
        public ActionResult GetColors(DataSourceLoadOptions loadOptions)
        {
            var result = customerInfo.GetEntities(loadOptions);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerInfoDto>> GetColor(int id)
        {
            var color = await customerInfo.FindEntity(id);

            if (color == null)
            {
                return NotFound();
            }

            return Ok(color);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor([FromForm] int key, [FromForm] string values)
        {
            var result = await customerInfo.PutEntity(key, values);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> PostColors([FromForm] string values)
        {
            await customerInfo.PostEntities(values);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerInfoDto>> DeleteColor(int id)
        {
            var color = await customerInfo.DeleteEntity(id);
            if (color == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
