using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Services;
using InventoryManagement.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionCardController : BaseController<TransactionCard, TransactionCardDto>
    {
        public TransactionCardController(IService<TransactionCard, TransactionCardDto> service) : base(service)
        {
        }
    }
}
