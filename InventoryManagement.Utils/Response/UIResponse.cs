using System.Collections;
using System.Net;

namespace InventoryManagement.Utils.Response
{
    public class UIResponse
    {
        //[AutoWrapperPropertyMap(Prop.Result)]
        public IEnumerable data { get; set; }
        public int totalCount { get; set; }
        public int groupCount { get; set; }
        public object[] summary { get; set; }
        public object Entity { get; set; }
        public string Type { get; set; }
        //[AutoWrapperPropertyMap(Prop.Message)]
        public string Message { get; set; }
        //[AutoWrapperPropertyMap(Prop.IsError)]
        public bool IsError { get; set; } = false;
        //[AutoWrapperPropertyMap(Prop.ResponseException)]
        public object Error { get; set; }
        //[AutoWrapperPropertyMap(Prop.StatusCode)]
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

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
