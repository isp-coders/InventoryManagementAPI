using AutoMapper;
using InventoryManagement.Application.Services.ProductPropertyService.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Core.Models;

namespace InventoryManagement.Application.Services.ProductPropertyService
{
    public class ProductPropertyService : Service<ProductProperty, ProductPropertyDto>, IProductPropertyService
    {
        private readonly IRepository<ProductProperty> _ProductPropertyRepository;
        private readonly IMapper _mapper;
        public ProductPropertyService(IRepository<ProductProperty> ProductPropertyRepository, IMapper _mapper) : base(ProductPropertyRepository, _mapper)
        {
            this._mapper = _mapper;
            _ProductPropertyRepository = ProductPropertyRepository;
        }
    }
}
