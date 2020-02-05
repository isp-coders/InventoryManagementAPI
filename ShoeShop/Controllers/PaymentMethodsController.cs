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

        private readonly IPaymentMethodsRepository _paymentMethodsRepository;

        public PaymentMethodsController(IPaymentMethodsRepository paymentMethodsRepository)
        {
            _paymentMethodsRepository = paymentMethodsRepository;
        }

        // GET: api/PaymentMethods
        [HttpGet]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var result = await _paymentMethodsRepository.GetPaymentMethods();
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
            var result = new Exception();
            try
            {
                result = await _paymentMethodsRepository.PutPaymentMethod(id, PaymentMethod);
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

        // POST: api/PaymentMethods
        [HttpPost]
        public async Task<ActionResult<PaymentMethod>> PostPaymentMethods(PaymentMethod[] PaymentMethod)
        {
            await _paymentMethodsRepository.PostPaymentMethods(PaymentMethod);
            return Ok();
        }

        // DELETE: api/PaymentMethods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentMethod>> DeletePaymentMethod(int id)
        {
            var PaymentMethod = await _paymentMethodsRepository.DeletePaymentMethod(id);
            if (PaymentMethod is KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
