using InventoryManagement.Application.Services.ProductPropertyService.DTOs;

namespace InventoryManagement.Application.Services.ProductTypeService.DTOs
{
    public class ProductTypeAndPropertyDto
    {
        public int ProductPropertyId { get; set; }
        public ProductPropertyDto ProductProperty { get; set; }
        public int ProductTypeId { get; set; }
        public ProductTypeDto ProductType { get; set; }
    }
}
