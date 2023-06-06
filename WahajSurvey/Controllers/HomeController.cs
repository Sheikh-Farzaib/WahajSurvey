using DBHandler.Models;
using DBHandler.Repositories.Implementation;
using DBHandler.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using ServicesManagmentPortal.ViewModels.MenuDTOs;
using System.Diagnostics;
using System.Globalization;
using WahajSurvey.Models;
using WahajSurvey.Models.DTOs;

namespace WahajSurvey.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IItemRepository _item;
        private readonly IBranchRepository _branch;

        public HomeController(ICategoryRepository category, IItemRepository item, IBranchRepository branch)
        {
            _categoryRepository = category;
            _item = item;
            _branch = branch;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> CategoryList(int branchId)
        {
            try
            {

                var result = (await _categoryRepository.GetAll(branchId))
                    .Select(x => new CategoryDto
                    {
                        CategoryId = x.CategoryId,
                        CategoryName = x.CategoryName,
                        CategoryNameAR = x.CategoryNameAR,
                        Status = x.Status.HasValue && x.Status.Value ? "Active" : "In-Active"
                    }).ToList();

                if (result != null)
                    return Json(result);

                return BadRequest(new { error = false });
            }
            catch (Exception ex)
            {

                Response.Headers.Add("X-Error-Message", ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> SubmitSurvery(SubmittedDataDTO submittedAnswers)
        {
            try
            {
                var submitAnswers = submittedAnswers.ItemsWithCat.Select(row => new SubmittedAnswer()
                {

                    BranchId = submittedAnswers.BranchId,
                    Comment = submittedAnswers.Comment,
                    Name = submittedAnswers.Name,
                    IdOrPhoneNumber = submittedAnswers.IdOrPhoneNumber,
                    CategoryId = int.Parse(row.Split("-")[1]),
                    ItemId = int.Parse(row.Split("-")[0]),
                    CreatedBy = submittedAnswers.Name,
                    CreatedOn = DateTime.Now
                }).ToList();


                var result = await _item.CreateSurvery(submitAnswers);
                return Json(new { status = true });



            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> BranchList()
        {
            try
            {
                var result = await _branch.GetList();

                if (result != null)
                    return Json(result);

                return BadRequest(new { error = false });
            }
            catch (Exception ex)
            {

                Response.Headers.Add("X-Error-Message", ex.Message);
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> CategoryById(int? categoryId, int branchId)
        {
            try
            {

                var result = await _categoryRepository.GetById(branchId);

                if (result != null)
                    return Json(result);

                return BadRequest(new { error = false });
            }
            catch (Exception ex)
            {

                Response.Headers.Add("X-Error-Message", ex.Message);
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> AddCategory(Category categoryVM)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest(new { error = false });

                var catagory = new Category
                {
                    CategoryId = categoryVM.CategoryId,
                    CategoryName = categoryVM.CategoryName,
                    Status = categoryVM.Status,
                    CreatedBy = "Admin",
                    CreatedOn = DateTime.Now,
                };

                var result = await _categoryRepository.Create(catagory);

                if (result)
                    return Json(new { success = result });

                return BadRequest(new { error = result });
            }
            catch (Exception ex)
            {

                Response.Headers.Add("X-Error-Message", ex.Message);
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> ItemListByCategoryId(int categoryId)
        {
            try
            {
                var result = await _item.GetItemsByCategoryId(categoryId);

                if (result != null)
                    return Json(result);

                return BadRequest(new { error = false });
            }
            catch (Exception ex)
            {

                Response.Headers.Add("X-Error-Message", ex.Message);
                return BadRequest(ex.Message);
            }
        }


    }
}