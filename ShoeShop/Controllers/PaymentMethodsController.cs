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
    public class PaymentMethodsController : ControllerBase
    {

        private readonly IPaymentMethodsRepository _paymentMethodsService;

        public PaymentMethodsController(IPaymentMethodsRepository paymentMethodsRepository)
        {
            _paymentMethodsService = paymentMethodsRepository;
        }

        // GET: api/PaymentMethods
        [HttpGet]
        public IActionResult GetPaymentMethods()
        {
            var result = _paymentMethodsService.GetEntities();
            return Ok(result);
        }

        // PUT: api/PaymentMethods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMethod(int id, PaymentMethod PaymentMethod)
        {
            if (id != PaymentMethod.Id)
            {
                return BadRequest();
            }
            var result = await _paymentMethodsService.PutEntity(id, PaymentMethod);

            if (result is null)
            {
                return NotFound();
            }


            return NoContent();
        }

        // POST: api/PaymentMethods
        [HttpPost]
        public async Task<ActionResult<PaymentMethod>> PostPaymentMethods(PaymentMethod[] PaymentMethod)
        {
            await _paymentMethodsService.PostEntities(PaymentMethod);
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
