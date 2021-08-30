using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Core.Models;

namespace InventoryManagement.Application.AutoMapper.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionDto>();
        }
    }

    public class ToTransactionProfile : Profile
    {
        public ToTransactionProfile()
        {
            CreateMap<TransactionDto, Transaction>();
        }
    }
}
