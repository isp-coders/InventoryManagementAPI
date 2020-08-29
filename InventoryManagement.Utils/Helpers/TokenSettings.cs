using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Utils.Helpers
{
    public class TokenSettings
    {
        public int ExpireMinutes { get; set; }
        public string Secret { get; set; }
        public string Issuer { get; set; }
    }
}
