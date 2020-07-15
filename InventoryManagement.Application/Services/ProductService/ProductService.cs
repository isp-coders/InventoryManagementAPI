using AutoMapper;
using InventoryManagement.Application.Services.ProductService.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.ProductService
{
    public class ProductService : Service<Product,ProductDto>, IProductService
    {

        private readonly IRepository<Product> _ProductRepository;
        private readonly IMapper _mapper;
        public ProductService(IRepository<Product> ProductRepository, IMapper _mapper) : base(ProductRepository,_mapper)
        {
            _ProductRepository = ProductRepository;
        }
    }
}
