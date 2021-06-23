using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Core.Models;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    public class TransactionCardProfile : Profile
    {
        public TransactionCardProfile()
        {
            CreateMap<TransactionCard, TransactionCardDto>();
        }
    }

    public class ToTransactionCardProfile : Profile
    {
        public ToTransactionCardProfile()
        {
            CreateMap<TransactionCardDto, TransactionCard>();
        }
    }
}
