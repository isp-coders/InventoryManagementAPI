using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;
using InventoryManagement.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Application.Services.PaymentMethodRepository;
using InventoryManagement.Application.Services.PaymentMethodService.DTOs;
using DevExtreme.AspNet.Data;
using Sample;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentMethodsController : ControllerBase
    {

        private readonly IPaymentMethodService _paymentMethodsService;

        public PaymentMethodsController(IPaymentMethodService paymentMethodsRepository)
        {
            _paymentMethodsService = paymentMethodsRepository;
        }

        // GET: api/PaymentMethods
        [HttpGet]
        public IActionResult GetPaymentMethods(DataSourceLoadOptions loadOptions)
        {
            var result = _paymentMethodsService.GetEntities(loadOptions);
            return Ok(result);
        }

        // PUT: api/PaymentMethods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMethod([FromForm] int key, [FromForm] string values)
        {

            var result = await _paymentMethodsService.PutEntity(key, values);

            if (result is null)
            {
                return NotFound();
            }


            return NoContent();
        }

        // POST: api/PaymentMethods
        [HttpPost]
        public async Task<ActionResult<PaymentMethod>> PostPaymentMethods([FromForm] string values)
        {
            await _paymentMethodsService.PostEntities(values);
            return Ok();
        }

        // DELETE: api/PaymentMethods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentMethod>> DeletePaymentMethod(int id)
        {
            var PaymentMethod = await _paymentMethodsService.DeleteEntity(id);
            if (PaymentMethod is null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
