using InventoryManagement.Utils.Exceptions;
using InventoryManagement.Utils.Response;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace InventoryManagement.Interface.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public UIResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error; // Your exception

            if (exception is InventoryManagementException)
            {
                var IMExeption = exception as InventoryManagementException;
                return new UIResponse { IsError = true, Message = IMExeption.Message, StatusCode = IMExeption.StatusCode };
            }
            else if (exception.InnerException is SqlException)
            {
                var sqlException = exception.InnerException as SqlException;
                if (sqlException.Number == 547)
                {
                    return new UIResponse { IsError = true, Message = "EXCEPTIONS.SQL_RELATIONSHIP", StatusCode = HttpStatusCode.InternalServerError };
                }
                else
                {
                    return new UIResponse { IsError = true, Message = "SQL", StatusCode = HttpStatusCode.InternalServerError };
                }
            }
            else
            {
                return new UIResponse() { IsError = true, StatusCode = HttpStatusCode.InternalServerError, Message = exception.Message };
            }
        }
    }
}
