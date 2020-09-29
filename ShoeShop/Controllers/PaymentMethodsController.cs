using InventoryManagement.Application.Services.PaymentMethodRepository;
using InventoryManagement.Application.Services.PaymentMethodService.DTOs;
using InventoryManagement.Models;
using InventoryManagement.Utils.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sample;
using System.Threading.Tasks;

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
        [HttpGet("Get")]
        public IActionResult GetPaymentMethods(DataSourceLoadOptions loadOptions)
        {
            var result = _paymentMethodsService.GetEntities(loadOptions);
            return Ok(result);
        }

        // PUT: api/PaymentMethods/5
        [HttpPost("Update/{id}")]
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
        [HttpPost("Insert")]
        public async Task<ActionResult<PaymentMethodDto>> PostPaymentMethod([FromForm] string values)
        {
            PaymentMethodDto Entity = new PaymentMethodDto();
            JsonConvert.PopulateObject(values, Entity);
            await _paymentMethodsService.PostEntity(Entity);
            return Ok();
        }

        // DELETE: api/PaymentMethods/5
        [HttpPost("Delete")]
        public async Task<ActionResult<PaymentMethod>> DeletePaymentMethod([FromForm] int Key)
        {
            var PaymentMethod = await _paymentMethodsService.DeleteEntity(Key);

            if (PaymentMethod == null)
            {
                return NotFound(new UIResponse() { IsError = true, Message = "STOCK_MODULE.MASTER_DATA.NOT_FOUND" });
            }

            return Ok(new UIResponse() { Entity = PaymentMethod });
        }
    }
}
