using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repositories
{
    public interface IColorsRepository
    {
        Task<IEnumerable<Color>> GetColors();
        Task<Color> GetColor(int id);
        Task<Exception> PutColor(int id, Color color);
        Task<Color> PostColor(Color color);
        Task<Color> PostColors(Color[] color);
        Task<Exception> DeleteColor(int id);
    }
}
