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
    public class ToCampaignProfile : Profile
    {
        public ToCampaignProfile()
        {
            CreateMap<CampaignDto, Campaign>();
        }
    }
}
