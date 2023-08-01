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
    public class SurveyRepository : ISurveyRepository
    {
        private readonly ApplicationDbContext _context;

        public SurveyRepository(ApplicationDbContext applicationDb)
        {
            _context = applicationDb;
        }
        public async Task<bool> CreateSurvery(List<SubmittedAnswer> submittedAnswer)
        {
            await _context.SubmittedAnswers.AddRangeAsync(submittedAnswer);
            await _context.SaveChangesAsync();
            return true;
        }
       public async Task<List<SubmittedAnswer>> SurveyAnswersList() =>
            await _context.SubmittedAnswers.ToListAsync();
        public virtual async Task<List<SubmittedAnswer>> SurveyAnswersListByCategoryId(int categoryId) =>
            await _context.SubmittedAnswers.Where(whr=>whr.CategoryId == categoryId).ToListAsync();
        public virtual async Task<List<SubmittedAnswer>> SurveyAnswersListByBranchId(List<int> branchId)
        {
            var result = await _context.SubmittedAnswers
        .Where(predicate: whr => branchId.Contains(whr.BranchId))
        .ToListAsync();
            return result;
        }   
        public virtual async Task<List<SubmittedAnswer>> SurveyAnswersListByBranchId(int branchId)
        {
            var result = await _context.SubmittedAnswers
        .Where(predicate: whr => whr.BranchId == branchId)
        .ToListAsync();
            return result;
        }
        public virtual async Task<List<SubmittedAnswer>> SurveyAnswersListByFromDateToDate(int branchId,DateTime from, DateTime to)
        {
            var result = await _context.SubmittedAnswers
        .Where(predicate: whr => whr.BranchId == branchId && whr.CreatedOn > from && whr.CreatedOn < to)
        .ToListAsync();
            return result;
        }
        public virtual async Task<List<SubmittedAnswer>> SurveyAnswersListByCategoryId(List<int> categoryId)
        {
            var result = await _context.SubmittedAnswers
        .Where(predicate: whr => categoryId.Contains(whr.CategoryId))
        .ToListAsync();
            return result;
        }


    }
}
