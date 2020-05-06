using InventoryManagement.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using ShoeShop.Data;
using ShoeShop.Models;
using ShoeShop.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repositories
{
    public class PaymentMethodsRepository : Repository<PaymentMethod>, IPaymentMethodsRepository
    {
        private readonly ShoeShopContext _context;
        public PaymentMethodsRepository(ShoeShopContext context): base(context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<PaymentMethod>> GetPaymentMethods()
        //{
        //    return await _context.PaymentMethods.ToListAsync();
        //}

        //public async Task<Exception> PutPaymentMethod(int id, PaymentMethod PaymentMethod)
        //{

        //    _context.Entry(PaymentMethod).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PaymentMethodExists(id))
        //        {
        //            return new KeyNotFoundException();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return null;
        //}

        //private bool PaymentMethodExists(int id)
        //{
        //    return _context.PaymentMethods.Any(e => e.Id == id);
        //}

        //public async Task<PaymentMethod> PostPaymentMethods(PaymentMethod[] PaymentMethods)
        //{
        //    _context.PaymentMethods.AddRange(PaymentMethods);
        //    await _context.SaveChangesAsync();

        //    return null;
        //}

        //public async Task<Exception> DeletePaymentMethod(int id)
        //{
        //    var PaymentMethod = await _context.PaymentMethods.FindAsync(id);
        //    if (PaymentMethod == null)
        //    {
        //        return new KeyNotFoundException();
        //    }

        //    _context.PaymentMethods.Remove(PaymentMethod);
        //    await _context.SaveChangesAsync();

        //    return null;
        //}
    }
}
