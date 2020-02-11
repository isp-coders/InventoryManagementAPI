
using ShoeShop.Data;
using ShoeShop.DTOs;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repositories
{
    public class NormalSaleRepository
    {
        private readonly ShoeShopContext _context;
        public NormalSaleRepository(ShoeShopContext context)
        {
            _context = context;
        }
    }
}
