using DBHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHandler.Repositories.Interface
{
    public interface IItemRepository
    {
        Task<Item> GetById(int id, int branchid);
        Task<List<Item>> GetAll(int branchId);
        Task<List<Item>> GetItemsByCategoryId(int categoryId);
        Task<bool> CreateSurvery(List<SubmittedAnswer> submittedAnswer);
    }
}
