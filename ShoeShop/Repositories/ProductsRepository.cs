using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoeShop.Data;
using ShoeShop.DTOs;
using ShoeShop.Models;
using ShoeShop.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ShoeShopContext _context;
        private readonly IMapper _mapper;

        public ProductsRepository(ShoeShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewDto>> GetProducts()
        {
            return await _mapper.ProjectTo<ProductViewDto>(_context.Products.Include(inc => inc.Branch).Include(inc => inc.Color)).ToListAsync();
            //return await _context.Products.Include(inc => inc.Branch).Include(inc => inc.Color).ToListAsync();
        }

        public async Task<Exception> PutProduct(int id, Product product)
        {

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return new KeyNotFoundException();
                }
                else
                {
                    throw;
                }
            }

            return null;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        public async Task<Product> PostProducts(Product[] products)
        {
            _context.Products.AddRange(products);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<Exception> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return new KeyNotFoundException();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return null;
        }
    }
}
