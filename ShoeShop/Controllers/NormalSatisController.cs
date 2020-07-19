
using InventoryManagement.Application.Services.SalesService;
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.DTOs;
using InventoryManagement.Repositories;
using InventoryManagement.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormalSatisController : ControllerBase
    {
        private readonly ISalesService _SalesService;
        public NormalSatisController(ISalesService salesService)
        {
            _SalesService = salesService;
        }

        // GET: api/Branches
        [HttpGet]
        public ActionResult GetBranches()
        {
            return Ok("ERROR");
        }

        [Route("GetProductDetails/{ProductFullCode}")]
        [HttpGet]
        public ActionResult GetProductDetails(string ProductFullCode)
        {
            var result = _SalesService.GetProductDetails(ProductFullCode);
            return Ok(result);
        }

        [Route("SellProducts")]
        [HttpPost]
        public async Task<ActionResult> SellProducts([FromForm] string values)
        {
            ProductSellingDto productSellingDto = new ProductSellingDto();
            JsonConvert.PopulateObject(values, productSellingDto);
            await _SalesService.SellProducts(productSellingDto);
            return Ok();
        }

        [Route("GetSelledProductsByUserId/{Id}/{StartDate?}/{EndDate?}")]
        [HttpGet]
        public ActionResult GetSelledProductsByUserId(int Id, DateTime StartDate, DateTime EndDate)
        {
            return Ok(_SalesService.GetSelledProductsByUserId(Id, StartDate, EndDate));
        }
    }
}
