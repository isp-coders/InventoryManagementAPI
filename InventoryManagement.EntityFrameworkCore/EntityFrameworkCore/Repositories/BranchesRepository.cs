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
    public class BranchesRepository : Repository<Branch>, IBranchesRepository
    {
        private readonly ShoeShopContext _context;
        public BranchesRepository(ShoeShopContext context): base(context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Branch>> GetBranches()
        //{
        //    return await _context.Branches.ToListAsync();
        //}

        //public async Task<Exception> PutBranch(int id, Branch branch)
        //{

        //    _context.Entry(branch).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BranchExists(id))
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

        //private bool BranchExists(int id)
        //{
        //    return _context.Branches.Any(e => e.Id == id);
        //}

        //public async Task<Branch> PostBranches(Branch[] branch)
        //{
        //    _context.Branches.AddRange(branch);
        //    await _context.SaveChangesAsync();

        //    return null;
        //}

        //public async Task<Exception> DeleteBranch(int id)
        //{
        //    var branch = await _context.Branches.FindAsync(id);
        //    if (branch == null)
        //    {
        //        return new KeyNotFoundException();
        //    }

        //    _context.Branches.Remove(branch);
        //    await _context.SaveChangesAsync();

        //    return null;
        //}
    }
}
