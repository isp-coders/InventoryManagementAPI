using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShop.Repositories.IRepositories
{
    public interface IBranchesRepository
    {
        Task<IEnumerable<Branch>> GetBranches();
        Task<Exception> PutBranch(int id, Branch branch);
        Task<Branch> PostBranches(Branch[] branches);
        Task<Exception> DeleteBranch(int id);
    }
}
