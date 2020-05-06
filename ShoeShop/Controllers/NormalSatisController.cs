
using InventoryManagement.Application.Services.SalesService;
using Microsoft.AspNetCore.Mvc;
using ShoeShop.DTOs;
using ShoeShop.Repositories;
using ShoeShop.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Controllers
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
        public async Task<ActionResult> SellProducts(ProductSellingDto productSellingDto)
        {
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
