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
using InventoryManagement.Application.Services.SalesService.DTOs;
using System.Collections.Generic;

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

        [Route("GetProductDetails/{ProductBarcode}")]
        [HttpGet]
        public UIResponse GetProductDetails(string ProductBarcode)
        {
            var result = _SalesService.GetProductDetails(ProductBarcode);

            UIResponse response = new UIResponse();
            if (result is null)
            {
                throw new InventoryManagementException("EXCEPTIONS.NO_SUCH_PRODUCT", HttpStatusCode.BadRequest);
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
            return result;
        }

        [Route("GetCustomerPurchasedProducts")]
        [HttpGet]
        public UIResponse GetCustomerPurchasedProducts(int CustomerInfoId, DataSourceLoadOptions loadOptions)
        {
            var result = _SalesService.GetCustomerPurchasedProducts(CustomerInfoId, loadOptions);
            return result;
        }

        [Route("RefundProducts")]
        [HttpPost]
        public async Task<UIResponse> RefundProducts([FromForm] string values)
        {
            List<SaleDetailsAndProductDto> saleDetailsAndProductDtos = new List<SaleDetailsAndProductDto>();
            JsonConvert.PopulateObject(values, saleDetailsAndProductDtos);
            var result = await _SalesService.RefundProducts(saleDetailsAndProductDtos);
            return result;
        }

        [Route("ChangeProducts")]
        [HttpPost]
        public async Task<UIResponse> ChangeProducts([FromForm] string values)
        {
            ChangeProductDto ChangeProductDto = new ChangeProductDto();
            JsonConvert.PopulateObject(values, ChangeProductDto);
            var result = await _SalesService.ChangeProducts(ChangeProductDto);
            return result;
        }

    }
}
