using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Core.Models;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<Currency, CurrencyDto>();
        }
    }

    public class ToCurrencyProfile : Profile
    {
        public ToCurrencyProfile()
        {
            CreateMap<CurrencyDto, Currency>();
        }
    }
}
