using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using InventoryManagement.Utils.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    class LoadResultToUIResponseProfile : Profile
    {
        public LoadResultToUIResponseProfile()
        {
            CreateMap<LoadResult, UIResponse>()
                 .ForMember(q => q.data, opt => opt.MapFrom(s => s.data))
                 .ForMember(q => q.groupCount, opt => opt.MapFrom(s => s.groupCount))
                 .ForMember(q => q.summary, opt => opt.MapFrom(s => s.summary))
                 .ForMember(q => q.totalCount, opt => opt.MapFrom(s => s.totalCount));
        }
    }
}
