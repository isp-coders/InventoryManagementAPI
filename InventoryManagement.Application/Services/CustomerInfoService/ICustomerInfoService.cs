using InventoryManagement.Application.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.CustomerInfoService
{
    public interface ICustomerInfoService : IService<CustomerInfo, CustomerInfoDto>
    {
    }
}
