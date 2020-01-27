using Microsoft.EntityFrameworkCore;
using ShoeShop.Data;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repositories
{
    public class ColorsRepository : IColorsRepository
    {
        private readonly ShoeShopContext _context;
        public ColorsRepository(ShoeShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Color>> GetColors()
        {
            return await _context.Colors.ToListAsync();
        }

        public async Task<Color> GetColor(int id)
        {
            var color = await _context.Colors.FindAsync(id);
            return color;
        }

        public async Task<Exception> PutColor(int id, Color color)
        {

            _context.Entry(color).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExists(id))
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

        private bool ColorExists(int id)
        {
            return _context.Colors.Any(e => e.Id == id);
        }


        public async Task<Color> PostColor(Color color)
        {
            _context.Colors.Add(color);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<Exception> DeleteColor(int id)
        {
            var color = await _context.Colors.FindAsync(id);
            if (color == null)
            {
                return new KeyNotFoundException();
            }

            _context.Colors.Remove(color);
            await _context.SaveChangesAsync();

            return null;
        }
    }
}
