using InventoryManagement.Application.Services.ProductPropertyService.DTOs;
using Newtonsoft.Json;

namespace InventoryManagement.Application.Services.ProductTypeService.DTOs
{
    public class ProductTypeAndPropertyDto
    {
        public int ProductPropertyId { get; set; }
        public ProductPropertyDto ProductProperty { get; set; }
        public int ProductTypeId { get; set; }
        [JsonIgnore]
        public ProductTypeDto ProductType { get; set; }
    }
}
