using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Core.Models
{
    public class ProductProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<ProductTypeAndProperty> ProductTypeAndProperties { get; set; }
    }
}
