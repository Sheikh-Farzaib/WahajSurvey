using DBHandler.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHandler.Model;
using Microsoft.EntityFrameworkCore;

namespace DBHandler.Repositories.Implementation
{
    public class BranchRepository : IBranchRepository
    {

        private ApplicationDbContext _ctx;

        public BranchRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Branch> Add(Branch branch)
        {
            _ctx.Branches.Add(branch);
            var isAdded = await _ctx.SaveChangesAsync() > 0;
            return branch;
        }

        public async Task<Branch> GetById(int Id)
        {
            return await _ctx.Branches.FirstOrDefaultAsync(b => b.BranchId == Id);
        }


        public async Task<List<Branch>> GetList()
        {

            return await _ctx.Branches.ToListAsync();

        }

    }
}
