using DevExtreme.AspNet.Data.ResponseModel;
using InventoryManagement.Application.Services.ProductService.DTOs;
using InventoryManagement.Models;
using InventoryManagement.Utils.Response;
using Sample;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.ProductService
{
    public interface IProductService : IService<Product, ProductDto>
    {
        public Task<UIResponse> AddNewProducts(string values);
        LoadResult GetProducts(DataSourceLoadOptions loadOptions);
    }
}
