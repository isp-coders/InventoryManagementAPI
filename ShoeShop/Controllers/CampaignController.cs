using InventoryManagement.Application.Services;
using InventoryManagement.Application.Services.CampaignService;
using InventoryManagement.Application.Services.CampaignService.DTOs;
using InventoryManagement.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CampaignController : BaseController<Campaign, CampaignDto>
    {
        public CampaignController(IService<Campaign, CampaignDto> service) : base(service)
        {
        }
    }
}
