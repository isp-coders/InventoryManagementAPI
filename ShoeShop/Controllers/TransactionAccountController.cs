using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Services;
using InventoryManagement.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sample;

namespace InventoryManagement.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionAccountController : BaseController<Transaction, TransactionDto>
    {
        public TransactionAccountController(IService<Transaction, TransactionDto> service) : base(service)
        {
        }

        public override ActionResult Get(DataSourceLoadOptions loadOptions)
        {
            loadOptions.RemoteGrouping = false;
            return base.Get(loadOptions);
        }
    }
}
