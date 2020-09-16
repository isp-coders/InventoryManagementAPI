using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace InventoryManagement.Utils.Exceptions
{
    public class InventoryManagementException : Exception
    {
        public string Type { get; set; }
        public bool IsError { get; set; }
        public object Error { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public InventoryManagementException(string Message, HttpStatusCode StatusCode) : base(Message)
        {
            this.StatusCode = StatusCode;
        }
    }
}
