using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagement.Core.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductTypeAndProperty> ProductTypeAndProperties { get; set; }

    }
}
