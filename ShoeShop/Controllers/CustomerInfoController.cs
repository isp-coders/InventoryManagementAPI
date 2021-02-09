using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Services.CustomerInfoService;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class CustomerInfoController : ControllerBase
    {
        private readonly ICustomerInfoService customerInfo;

        public CustomerInfoController(ICustomerInfoService customerInfo)
        {
            this.customerInfo = customerInfo;
        }


        [HttpGet("Get")]
        public ActionResult GetCustomers(DataSourceLoadOptions loadOptions)
        {
            var result = customerInfo.GetEntities(loadOptions);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerInfoDto>> GetCustomer(int id)
        {
            var customer = await customerInfo.FindEntity(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }


        [HttpPost("Update/{id}")]
        public async Task<IActionResult> PutCustomer([FromForm] int key, [FromForm] string values)
        {
            var result = await customerInfo.PutEntity(key, values);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);
        }


        [HttpPost("Insert")]
        public async Task<ActionResult> PostCustomers([FromForm] string values)
        {
            await customerInfo.PostEntities(values);
            return Ok();
        }


        [HttpPost("Delete")]
        public async Task<ActionResult<CustomerInfoDto>> DeleteCustomer(int id)
        {
            var customer = await customerInfo.DeleteEntity(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
