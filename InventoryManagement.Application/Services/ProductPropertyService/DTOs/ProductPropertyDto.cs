using InventoryManagement.Application.Services.ProductTypeService.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.ProductPropertyService.DTOs
{
    public class ProductPropertyDto
    {
        public int Id { get; set; }
        public string DataField { get; set; }
        public string Type { get; set; }
        public string Translate { get; set; }
        public string EditorType { get; set; }
        public string FormItemEditorOptions { get; set; }
        public string GridColumnEditorOptions { get; set; }
        public string Validation { get; set; }
        public string GridColumnConf { get; set; }
        public List<ProductTypeAndPropertyDto> ProductTypeAndProperties { get; set; }
    }
}
