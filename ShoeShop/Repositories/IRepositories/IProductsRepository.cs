using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repositories.IRepositories
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Exception> PutProduct(int id, Product branch);
        Task<Product> PostProducts(Product[] branches);
        Task<Exception> DeleteProduct(int id);
    }
}
