using InventoryManagement.Application.Services.PaymentMethodRepository;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.PaymentMethodService
{
    public class PaymentMethodService : Service<PaymentMethod>, IPaymentMethodService
    {
        private readonly IRepository<PaymentMethod> _PaymentMethodRepository;
        public PaymentMethodService(IRepository<PaymentMethod> PaymentMethodRepository) : base(PaymentMethodRepository)
        {
            _PaymentMethodRepository = PaymentMethodRepository;
        }
    }
}
