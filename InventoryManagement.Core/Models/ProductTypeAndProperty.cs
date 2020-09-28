using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Core.Models
{
    public class ProductTypeAndProperty
    {
        public int ProductPropertyId { get; set; }
        public ProductProperty ProductProperty { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}
