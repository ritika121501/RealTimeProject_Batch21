using Microsoft.AspNetCore.Mvc;
using RealTimeProject_Batch21.Models;
using RealTimeProject_Batch21.Services;

namespace RealTimeProject_Batch21.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //asynchrous operations -- performance tuning Task, async and await
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var listOfCategorys = await _categoryService.GetAllCategory();
            return View(listOfCategorys);
        }

        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            try
            {
                var emp = await _categoryService.CreateCategory(category);
                TempData["Success"] = "Category Added Successfully";
                return RedirectToAction("GetAllCategories");
            }
           catch(Exception ex)
            {
                TempData["error"] = "Duplicate Category Is Not Allowed";
                return RedirectToAction("GetAllCategories");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            Category category = await _categoryService.GetCategoryById(id);

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(Category emp)
        {
            if (emp != null)
            {
                var isCategoryUpdated = await _categoryService.UpdateCategory(emp);
                if (isCategoryUpdated)
                {
                    return RedirectToAction("GetAllCategorys");
                }
            }
            else
            {
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Category category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return BadRequest();
            }
            else
            {
                return View(category);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {


            return RedirectToAction("GetAllCategorys");
        }
    }
}
