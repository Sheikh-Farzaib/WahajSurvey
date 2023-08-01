using DBHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHandler.Repositories.Interface
{
    public interface ICategoryRepository
    {
       
        Task<Category> GetById(int branchId);
        Task<List<Category>> GetAll(int branchId);
        Task<bool> Create(Category category);
        Task<List<Category>> GetCategoriesListByIds(List<int> category);


    }
}
