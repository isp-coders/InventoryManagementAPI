using AutoMapper;
using InventoryManagement.Application.Services.ProductTypeService.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Core.Models;
using InventoryManagement.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.ProductTypeService
{
    public class ProductTypeService : Service<ProductType, ProductTypeDto>, IProductTypeService
    {
        private readonly IRepository<ProductType> _ProductTypeRepository;
        private readonly IRepository<ProductTypeAndProperty> _ProductTypeAndPropertyRepository;
        private readonly IMapper _mapper;
        public ProductTypeService(IRepository<ProductType> ProductTypeRepository, IRepository<ProductTypeAndProperty> _ProductTypeAndPropertyRepository, IMapper _mapper) : base(ProductTypeRepository, _mapper)
        {
            this._mapper = _mapper;
            this._ProductTypeRepository = ProductTypeRepository;
            this._ProductTypeAndPropertyRepository = _ProductTypeAndPropertyRepository;
        }


        public async Task<UIResponse> AddPropertiesToProductType(AddPropertiesToProductTypeDto addPropertiesToProductTypeDto)
        {
            if (addPropertiesToProductTypeDto.ProductTypeId != 0 && addPropertiesToProductTypeDto.ProductProperties.Count > 0)
            {
                await _ProductTypeAndPropertyRepository.DeleteWhere(gq => gq.ProductTypeId == addPropertiesToProductTypeDto.ProductTypeId);
                List<ProductTypeAndProperty> productTypeAndProperties = new List<ProductTypeAndProperty>();
                addPropertiesToProductTypeDto.ProductProperties.ForEach(_productProperty =>
                {
                    productTypeAndProperties.Add(new ProductTypeAndProperty { ProductTypeId = addPropertiesToProductTypeDto.ProductTypeId, ProductPropertyId = _productProperty });
                });

                await _ProductTypeAndPropertyRepository.PostEntities(productTypeAndProperties);
                return new UIResponse();
            }
            else
            {
                return new UIResponse() { IsError = true };
            }

        }
    }
}
