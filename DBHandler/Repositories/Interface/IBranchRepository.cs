using DBHandler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHandler.Repositories.Interface {
    public interface IBranchRepository {
        Task<Branch> Add(Branch branch);
    
        Task<Branch> GetById(int Id);
        Task<List<Branch>> GetList();
    }
}
