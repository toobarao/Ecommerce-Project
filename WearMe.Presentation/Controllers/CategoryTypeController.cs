using Microsoft.AspNetCore.Mvc;
using WearMe.Business.Interface;
using WearMe.DataAccess.Entitities;

namespace WearMe.Presentation.Controllers
{
    public class CategoryTypeController : Controller
    {
        private readonly ICategoryTypeService _categoryTypeService;
        

        public CategoryTypeController(ICategoryTypeService categoryTypeService)
        {
            _categoryTypeService = categoryTypeService;
            
        }
        public async Task<IActionResult> Index()
        {
            var categoryTypes= await _categoryTypeService.GetCategoryTypesAsync();
            return View(categoryTypes);
        }
        public async Task<IActionResult> Create()
        {
            ViewData["categories"]=await _categoryTypeService.GetCategoriesAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryType categoryType)
        {
            Category category=new Category();
            category= await _categoryTypeService.GetCategoryByIdAsync(categoryType.Category.Id);
            categoryType.Category = category;
            await _categoryTypeService.AddCategoryTypeAsync(categoryType);

            return RedirectToAction("Index");
        }

    }
}
