using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repositories.IRepositories
{
    public interface IPaymentMethodsRepository
    {
        Task<IEnumerable<PaymentMethod>> GetPaymentMethods();
        Task<Exception> PutPaymentMethod(int id, PaymentMethod branch);
        Task<PaymentMethod> PostPaymentMethods(PaymentMethod[] branches);
        Task<Exception> DeletePaymentMethod(int id);
    }
}
