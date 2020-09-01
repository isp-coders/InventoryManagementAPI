using AutoWrapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace InventoryManagement.Utils.Response
{
    public class UIResponse
    {
        [AutoWrapperPropertyMap(Prop.Result)]
        public IEnumerable data { get; set; }
        public int totalCount { get; set; }
        public int groupCount { get; set; }
        public object[] summary { get; set; }
        public object Entity { get; set; }
        public string Type { get; set; }
        [AutoWrapperPropertyMap(Prop.Message)]
        public string Message { get; set; }
        [AutoWrapperPropertyMap(Prop.IsError)]
        public bool IsError { get; set; }
        [AutoWrapperPropertyMap(Prop.ResponseException)]
        public object Error { get; set; }
        [AutoWrapperPropertyMap(Prop.StatusCode)]
        public HttpStatusCode StatusCode { get; set; }

        public UIResponse()
        {

        }
        public UIResponse(string Message, HttpStatusCode StatusCode)
        {
            this.Message = Message;
            this.StatusCode = StatusCode;
        }
    }
}
