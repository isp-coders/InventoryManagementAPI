using AutoMapper;
using InventoryManagement.Application.Services.PaymentMethodRepository;
using InventoryManagement.Application.Services.PaymentMethodService.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.PaymentMethodService
{
    public class PaymentMethodService : Service<PaymentMethod, PaymentMethodDto>, IPaymentMethodService
    {
        private readonly IRepository<PaymentMethod> _PaymentMethodRepository;
        private readonly IMapper _mapper;
        public PaymentMethodService(IRepository<PaymentMethod> PaymentMethodRepository, IMapper _mapper) : base(PaymentMethodRepository, _mapper)
        {
            _PaymentMethodRepository = PaymentMethodRepository;
        }
    }
}
