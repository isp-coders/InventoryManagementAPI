using InventoryManagement.Application.Services.SalesService;
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.DTOs;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using InventoryManagement.Utils.Response;
using System.Net;
using AutoMapper;
using InventoryManagement.Utils.Exceptions;
using Sample;

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
                throw new InventoryManagementException("EXCEPTIONS.NO_SUCH_PRODUCT", HttpStatusCode.OK);
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

        [Route("GetSelledProductsByUserId")]
        [HttpGet]
        public UIResponse GetSelledProductsByUserId(int Id, DataSourceLoadOptions loadOptions)
        {
            var result = _SalesService.GetSelledProductsByUserId(Id, loadOptions);
            UIResponse uIResponse = new UIResponse() { data = result.data, StatusCode = HttpStatusCode.OK };
            return uIResponse;
        }
    }
}
