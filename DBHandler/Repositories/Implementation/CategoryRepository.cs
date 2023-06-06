using DBHandler.Model;
using DBHandler.Models;
using DBHandler.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DBHandler.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext applicationDb)
        {
            _context = applicationDb;
        }
        public async Task<bool> Create(Category category)
        {  
            await _context.Catagories.AddAsync(category);
            await _context.SaveChangesAsync();
            return true;
        }

 

        public async Task<List<Category>> GetAll(int branchId)
        => await _context.Catagories.Where(x=>x.BranchId == branchId).ToListAsync();

        public async Task<Category> GetById(int branchId) 
        => await _context.Catagories.FirstOrDefaultAsync(whr => whr.Branch.BranchId == branchId);

   
        

      
    }
}
