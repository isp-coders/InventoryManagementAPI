using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repositories.IRepositories
{
    public interface INormalSatisRepository
    {
        Product GetProductDetails(string ProductFullCode);
    }
}
