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
    public class NormalSatisRepository : INormalSatisRepository
    {
        private readonly ShoeShopContext _context;

        public NormalSatisRepository(ShoeShopContext context)
        {
            _context = context;
        }

        public Product GetProductDetails(string ProductFullCode)
        {
            return _context.Products.Include(inc=> inc.Color).Include(inc=> inc.Branch).SingleOrDefault(si => si.ProductFullCode == ProductFullCode);
        }
    }
}
