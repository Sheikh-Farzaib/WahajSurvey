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
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext applicationDb)
        {
            _context = applicationDb;
        }
        public async Task<bool> Create(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateSurvery(List<SubmittedAnswer> submittedAnswer)
        {
            await _context.SubmittedAnswers.AddRangeAsync(submittedAnswer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Item>> GetAll(int branchId) => await _context.Items
            .Where(whr=>whr.Category.Branch.BranchId == branchId)
            .ToListAsync();

        public async Task<Item> GetById(int id, int branchId) => 
            await _context.Items.FirstOrDefaultAsync(whr => whr.Category.Branch.BranchId == branchId && whr.ItemId == id);
        public async Task<List<Item>> GetItemsByCategoryId(int id) =>
            await _context.Items.Where(whr => whr.CategoryId == id)
            .ToListAsync();

   
    }
}
