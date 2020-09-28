using AutoMapper;
using InventoryManagement.Application.Services.ProductTypeService.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.ProductTypeService
{
    public class ProductTypeService : Service<ProductType, ProductTypeDto>, IProductTypeService
    {
        private readonly IRepository<ProductType> _ProductTypeRepository;
        private readonly IMapper _mapper;
        public ProductTypeService(IRepository<ProductType> ProductTypeRepository, IMapper _mapper) : base(ProductTypeRepository, _mapper)
        {
            this._mapper = _mapper;
            _ProductTypeRepository = ProductTypeRepository;
        }
    }
}
