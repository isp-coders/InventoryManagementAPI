using InventoryManagement.Utils.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sample;
using System;
using System.Reflection;

namespace InventoryManagement.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnumAsListController : ControllerBase
    {

        [HttpGet("Get")]
        public ActionResult Get(string enumName, DataSourceLoadOptions loadOptions)
        {
            if (!string.IsNullOrEmpty(enumName))
            {
                Type enumType = Type.GetType($"InventoryManagement.Core.Enums.{enumName},InventoryManagement.Core", true);

                MethodInfo returnEnumAsListMethod = typeof(EnumHelpers).GetMethod("ReturnEnumAsList",
                                    BindingFlags.Public | BindingFlags.Static);
                returnEnumAsListMethod = returnEnumAsListMethod.MakeGenericMethod(enumType);
                var result = returnEnumAsListMethod.Invoke(null, null);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
