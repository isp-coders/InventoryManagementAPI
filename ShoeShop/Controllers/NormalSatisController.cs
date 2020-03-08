
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
        private readonly INormalSatisRepository _normalSatisRepository;
        public NormalSatisController(INormalSatisRepository normalSatisRepository)
        {
            _normalSatisRepository = normalSatisRepository;
        }

        // GET: api/Branches
        [HttpGet]
        public ActionResult GetBranches()
        {
            return Ok("ERROR");
        }

        [Route("GetProductDetails/{ProductFullCode}")]
        [HttpGet]
        public async Task<ActionResult> GetProductDetails(string ProductFullCode)
        {
            var result = _normalSatisRepository.GetProductDetails(ProductFullCode);
            return Ok(await result);
        }

        [Route("SellProducts")]
        [HttpPost]
        public async Task<ActionResult> SellProducts(ProductSellingDto productSellingDto)
        {
            await _normalSatisRepository.SellProducts(productSellingDto);
            return Ok();
        }

        [Route("GetSelledProductsByUserId/{Id}/{StartDate?}/{EndDate?}")]
        [HttpGet]
        public async Task<ActionResult> GetSelledProductsByUserId(int Id, DateTime StartDate, DateTime EndDate)
        {
            return Ok(await _normalSatisRepository.GetSelledProductsByUserId(Id, StartDate, EndDate));
        }
    }
}
