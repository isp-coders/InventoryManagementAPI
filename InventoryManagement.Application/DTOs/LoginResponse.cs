using InventoryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;


namespace InventoryManagement.Application.DTOs
{
    public class LoginResponse
    {
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public UserStatus UserStatus { get; set; }
        public string Token { get; set; }
        public bool IsAuthenticated { get; set; }
        public List<NavigationItems> NavigationItems { get; set; }

        public LoginResponse()
        {
            NavigationItems = new List<NavigationItems>();
        }
    }
}
