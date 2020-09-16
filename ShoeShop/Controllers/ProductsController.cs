using InventoryManagement.Application.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Sample;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using InventoryManagement.Utils.Response;
using System.Net;
using InventoryManagement.Utils.Exceptions;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productsService, IMapper _mapper)
        {
            _productService = productsService;
            this._mapper = _mapper;
        }

        // GET: api/Products
        [HttpGet]
        public UIResponse GetProducts(DataSourceLoadOptions loadOptions)
        {
            var result = _productService.GetEntities(loadOptions);
            return _mapper.Map<UIResponse>(result);
        }

        // PUT: api/Products/5
        [HttpPut]
        public async Task<UIResponse> PutProduct([FromForm] int key, [FromForm] string values)
        {
            var result = await _productService.PutEntity(key, values);
            UIResponse response = new UIResponse();
            if (result is null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Entity = result;
            }
            return response;
        }

        // POST: api/Products
        [HttpPost]
        public async Task<UIResponse> PostProducts([FromForm] string values)
        {
            var result = await _productService.AddNewProducts(values);
            return result;
        }

        // DELETE: api/Products/5
        [HttpDelete]
        public async Task<ActionResult<UIResponse>> DeleteProduct([FromForm] int key)
        {
            var product = await _productService.DeleteEntity(key);
            UIResponse response = new UIResponse();
            if (product is null)
            {
                throw new InventoryManagementException("EXCEPTIONS.NO_SUCH_PRODUCT", HttpStatusCode.NotFound);
            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Entity = product;
            }
            return response;
        }
    }
}
