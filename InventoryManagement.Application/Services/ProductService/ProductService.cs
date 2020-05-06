using InventoryManagement.Core.IRepositories;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.ProductService
{
    public class ProductService : Service<Product>, IProductService
    {

        private readonly IRepository<Product> _ProductRepository;
        public ProductService(IRepository<Product> ProductRepository) : base(ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
    }
}
