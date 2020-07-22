using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.CustomerInfoService
{
    public class CustomerInfoService : Service<CustomerInfo, CustomerInfoDto>, ICustomerInfoService
    {
        private readonly IRepository<CustomerInfo> CustomerInfoRepository;
        private readonly IMapper _mapper;
        public CustomerInfoService(IRepository<CustomerInfo> CustomerInfoRepository, IMapper _mapper) : base(CustomerInfoRepository, _mapper)
        {
            CustomerInfoRepository = CustomerInfoRepository;
        }
    }
}
