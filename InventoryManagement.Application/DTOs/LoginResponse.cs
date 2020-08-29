using System;
using System.Collections.Generic;
using System.Text;


namespace InventoryManagement.Application.DTOs
{
    public class LoginResponse
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Translate { get; set; }
        public string Icon { get; set; }
        public string URL { get; set; }
        public List<LoginResponse> Children { get; set; }
    }
}
