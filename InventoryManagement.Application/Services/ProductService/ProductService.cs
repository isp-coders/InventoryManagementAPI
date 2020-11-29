using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Services.ProductService.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Core.Models;
using InventoryManagement.Models;
using InventoryManagement.Utils.Exceptions;
using InventoryManagement.Utils.Response;
using Newtonsoft.Json;
using Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.ProductService
{
    public class ProductService : Service<Product, ProductDto>, IProductService
    {

        private readonly IRepository<Product> _ProductRepository;
        private readonly IRepository<Campaign> _CampaignRepository;
        private readonly IMapper _mapper;
        public ProductService(IRepository<Product> ProductRepository, IRepository<Campaign> CampaignRepository, IMapper _mapper) : base(ProductRepository, _mapper)
        {
            _ProductRepository = ProductRepository;
            _CampaignRepository = CampaignRepository;
            this._mapper = _mapper;
        }

        public async Task<UIResponse> AddNewProducts(string values)
        {
            List<Product> Products = new List<Product>();
            JsonConvert.PopulateObject(values, Products);

            CheckBarcodeAndAddIt(Products);

            //AddProductsDto addProductsDto = new AddProductsDto();
            //List<Product> AddedNewProducts = new List<Product>();
            //CheckExistedProductCodes(Products, addProductsDto, AddedNewProducts);

            //if (AddedNewProducts.Count > 0)
            await _ProductRepository.PostEntities(Products);
            await _ProductRepository.SaveChangesAsync();
            return new UIResponse { data = Products, StatusCode = HttpStatusCode.OK };
        }

        private void CheckExistedProductCodes(List<Product> Products, AddProductsDto addProductsDto, List<Product> AddedNewProducts)
        {
            HashSet<string> ProductCodeList = new HashSet<string>(_ProductRepository.GetQuery().Select(se => se.ProductCode));

            Products.ForEach(product =>
            {
                var isExists = ProductCodeList.Contains(product.ProductCode);
                var productDto = _mapper.Map<ProductDto>(product);
                if (isExists)
                {
                    addProductsDto.ExistedProducts.Add(productDto);
                }
                else
                {
                    AddedNewProducts.Add(product);
                    addProductsDto.AddedProducts.Add(productDto);
                }
            });
        }

        private void CheckBarcodeAndAddIt(List<Product> Products)
        {
            HashSet<string> ProductFullCodeList = new HashSet<string>(_ProductRepository.GetQuery().Select(se => se.ProductBarcode));
            foreach (var item in Products)
            {
                if (item.ProductBarcode == null)
                {
                    string newBarcode = GenerateBarcode();
                    while (ProductFullCodeList.Any(an => an == newBarcode))
                    {
                        newBarcode = GenerateBarcode();
                    }
                    item.ProductBarcode = newBarcode;
                    ProductFullCodeList.Add(newBarcode);
                }
            }
        }

        private string GenerateBarcode()
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < 12; i++)
                s = String.Concat(s, random.Next(10).ToString());

            return s;
        }

        public UIResponse GetProducts(DataSourceLoadOptions loadOptions)
        {
            loadOptions.RemoteGrouping = false;
            var loadResult = DataSourceLoader.Load(_ProductRepository.GetQuery(null, null, "Campaign"), loadOptions);
            if (loadResult.data.OfType<Product>().Any())
            {
                loadResult.data = _mapper.Map<List<ProductDto>>(loadResult.data.Cast<Product>().ToList());
            }
            UIResponse response = _mapper.Map<UIResponse>(loadResult);
            return response;
        }

        public async Task<UIResponse> IncreaseProductCount(int ProductId, int Count)
        {
            Product product = _ProductRepository.GetQuery(gq => gq.Id == ProductId).FirstOrDefault();
            if (product != null)
            {
                product.Count += Count;
                if (product.Count < 0)
                {
                    product.Count = 0;
                }
            }
            _ProductRepository.PutEntity(product);
            await _ProductRepository.SaveChangesAsync();

            return new UIResponse { Entity = _mapper.Map<ProductDto>(product), StatusCode = HttpStatusCode.OK, IsError = false };

        }

        public async Task<UIResponse> ApplyCampaign(ApplyCampaignRequestDto applyCampaignDto)
        {
            if (applyCampaignDto.ProductsId.Count > 0 && applyCampaignDto.CampaignId != 0)
            {
                var list = _ProductRepository.GetQuery().Where(gq => applyCampaignDto.ProductsId.Any(productId => productId == gq.Id)).ToList();
                list.ForEach(fe =>
                {
                    fe.CampaignId = applyCampaignDto.CampaignId;
                });
                _ProductRepository.PutEntities(list);
                await _ProductRepository.SaveChangesAsync();
                return new UIResponse { Entity = applyCampaignDto };

            }
            else
            {
                throw new InventoryManagementException("EXCEPTIONS.ERROR", HttpStatusCode.BadRequest);
            }

        }
    }
}
