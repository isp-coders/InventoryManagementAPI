using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.ProductTypeService.DTOs
{
    public class AddPropertiesToProductTypeDto
    {
        public int ProductTypeId { get; set; }
        public List<int> ProductProperties { get; set; }
    }
}
