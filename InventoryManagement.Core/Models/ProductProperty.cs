using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagement.Core.Models
{
    public class ProductProperty
    {
        public int Id { get; set; }
        [StringLength(15)]
        public string DataField { get; set; }
        [StringLength(10)]
        public string Type { get; set; }
        [StringLength(100)]
        public string Translate { get; set; }
        [StringLength(30)]
        public string EditorType { get; set; }
        public string FormItemEditorOptions { get; set; }
        public string GridColumnEditorOptions { get; set; }
        public string Validation { get; set; }
        public string GridColumnConf { get; set; }
        public List<ProductTypeAndProperty> ProductTypeAndProperties { get; set; }
    }
}
