using DBHandler.Models;
using DBHandler.Repositories.Implementation;
using DBHandler.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using System.Collections.Generic;
using System.Text.Json;
using WahajSurvey.Models.DTOs;

namespace WahajSurvey.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ISurveyRepository _survey;
        private readonly IItemRepository _item;
        private readonly IBranchRepository _branchRepository;
        private readonly ICategoryRepository _categoryRepository;

        public DashboardController(ISurveyRepository survey, IItemRepository item, IBranchRepository branchRepository, ICategoryRepository categoryRepository)
        {
            _survey = survey;
            _item = item;
            _branchRepository = branchRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetSurveyAnswers()
        {
            try
            {
                var result = await _branchRepository.GetList();
                if (result.Count > 0)
                    return Json(result);

                return BadRequest(new { error = false });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetSurveyAnswersList(BranchIdWithDateFilterDTO branchIdWithDate)
        {
            try
            {
                List<SubmittedAnswer> result = new List<SubmittedAnswer>();

                List<SurveyChartDTO> chartDTOs = new List<SurveyChartDTO>();

                if (branchIdWithDate.ToDate.HasValue && branchIdWithDate.FromDate.HasValue)
                {
                    result = await _survey.SurveyAnswersListByFromDateToDate(branchIdWithDate.BranchId, branchIdWithDate.FromDate.Value, branchIdWithDate.ToDate.Value.AddDays(1));
                }
                else
                {
                 result = await _survey.SurveyAnswersListByBranchId(branchIdWithDate.BranchId);
                }
                
                var getCategoriesFromSurvey = result.Select(x => x.CategoryId).ToList();

                var getNamesAndId = await _categoryRepository.GetCategoriesListByIds(getCategoriesFromSurvey);

                var itemIds = result.Select(x => x.ItemId).Distinct().ToList();
                var itemNames = await _item.GetById(itemIds);
                var store = result.GroupBy(x => x.ItemId)
                                  .Select(selector: (select) => new
                                  {
                                      CategoryId = getNamesAndId.FirstOrDefault(x => x.CategoryId == select.FirstOrDefault().CategoryId)?.CategoryId,
                                      CategoryName = getNamesAndId.FirstOrDefault(x => x.CategoryId == select.FirstOrDefault().CategoryId)?.CategoryName,
                                      ItemId = select.Key,
                                      Count = select.Count(),
                                      ItemNames = itemNames.FirstOrDefault(i => i.ItemId == select.Key)?.ItemName
                                  })
                                  .OrderByDescending(x => x.Count).ToList();

                if (store.Count > 0)
                {
                    chartDTOs = store.Select(x => new { CategoryId = x.CategoryId, CategoryName = x.CategoryName }).DistinctBy(x => x.CategoryId).Select(cat => new SurveyChartDTO()
                    {
                        CategoryId = cat.CategoryId,
                        CategoryName = cat.CategoryName,
                        Items = store.Where(predicate: whr => (whr).CategoryId == cat.CategoryId).Select(itm => new ItemList()
                        {
                            ItemCount = itm.Count,
                            ItemId = itm.ItemId,
                            ItemName = itm.ItemNames,
                        }).ToList()

                    }).ToList();
                }

                if (chartDTOs.Count > 0)
                    return Json(chartDTOs);

                return BadRequest(new { error = false,message = "NO DATA FOUND" });


            }
            catch (Exception ex)
            {
               return BadRequest(new { error = false, message = "Something Went Wrong" });
            }
        }

    }
}
