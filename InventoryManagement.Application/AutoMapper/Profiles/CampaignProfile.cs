using AutoMapper;
using InventoryManagement.Application.Services.CampaignService.DTOs;
using InventoryManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    public class CampaignProfile : Profile
    {
        public CampaignProfile()
        {
            CreateMap<Campaign, CampaignDto>();
        }
    }
}
