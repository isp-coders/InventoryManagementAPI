using AutoMapper;
using InventoryManagement.Application.Services.CampaignService.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.CampaignService
{
    public class CampaignService : Service<Campaign, CampaignDto>, ICampaignService
    {
        private readonly IRepository<Campaign> _CampaignRepository;
        private readonly IMapper _mapper;
        public CampaignService(IRepository<Campaign> CampaignRepository, IMapper _mapper) : base(CampaignRepository, _mapper)
        {
            _CampaignRepository = CampaignRepository;
        }
    }
}
