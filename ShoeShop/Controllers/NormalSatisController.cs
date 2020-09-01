
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
using Microsoft.AspNetCore.Authorization;
using AutoWrapper.Wrappers;
using InventoryManagement.Utils;
using InventoryManagement.Utils.Response;
using System.Net;
using AutoMapper;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NormalSatisController : ControllerBase
    {
        private readonly ISalesService _SalesService;
        private readonly IMapper _mapper;
        public NormalSatisController(ISalesService salesService, IMapper _mapper)
        {
            _SalesService = salesService;
            this._mapper = _mapper;
        }

        [Route("GetProductDetails/{ProductFullCode}")]
        [HttpGet]
        public UIResponse GetProductDetails(string ProductFullCode)
        {
            var result = _SalesService.GetProductDetails(ProductFullCode);

            UIResponse response = new UIResponse();
            if (result is null)
            {
                throw new ApiException(new UIResponse("EXCEPTIONS.NO_SUCH_PRODUCT", HttpStatusCode.NotFound));
            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Entity = result;
            }
            return response;

        }

        [Route("SellProducts")]
        [HttpPost]
        public async Task<UIResponse> SellProducts([FromForm] string values)
        {
            ProductSellingDto productSellingDto = new ProductSellingDto();
            JsonConvert.PopulateObject(values, productSellingDto);
            await _SalesService.SellProducts(productSellingDto);
            return new UIResponse { StatusCode = HttpStatusCode.OK };
        }

        [Route("GetSelledProductsByUserId/{Id}/{StartDate?}/{EndDate?}")]
        [HttpGet]
        public UIResponse GetSelledProductsByUserId(int Id, DateTime StartDate, DateTime EndDate)
        {
            var result = _SalesService.GetSelledProductsByUserId(Id, StartDate, EndDate);
            UIResponse uIResponse = new UIResponse() { Entity = result, StatusCode = HttpStatusCode.OK };
            return uIResponse;
        }
    }
}
