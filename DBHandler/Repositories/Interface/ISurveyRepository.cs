using DBHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHandler.Repositories.Interface
{
    public interface ISurveyRepository
    {
        Task<bool> CreateSurvery(List<SubmittedAnswer> submittedAnswer);
        Task<List<SubmittedAnswer>> SurveyAnswersList();
        Task<List<SubmittedAnswer>> SurveyAnswersListByCategoryId(int categoryId);
        Task<List<SubmittedAnswer>> SurveyAnswersListByBranchId(List<int> branchId);
        Task<List<SubmittedAnswer>> SurveyAnswersListByCategoryId(List<int> categoryId);
        Task<List<SubmittedAnswer>> SurveyAnswersListByBranchId(int branchId);
        Task<List<SubmittedAnswer>> SurveyAnswersListByFromDateToDate(int branchId, DateTime from, DateTime to);
    }
}
