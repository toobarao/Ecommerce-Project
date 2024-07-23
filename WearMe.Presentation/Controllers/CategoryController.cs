using Microsoft.AspNetCore.Mvc;
using WearMe.Business.Interface;
using WearMe.DataAccess.Entitities;


namespace WearMe.Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = (List<Category>)await _categoryService.GetCategoriesAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            /*if (ModelState.IsValid)
            {*/
                await _categoryService.AddCategoryAsync(category);
                return RedirectToAction("Index");
           /* }
            else
            {
                return View();
            }*/
           
           
        }


    }
}
