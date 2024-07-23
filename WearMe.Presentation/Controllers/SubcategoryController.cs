using Microsoft.AspNetCore.Mvc;
using WearMe.Business.Interface;
using WearMe.DataAccess.Entitities;

namespace WearMe.Presentation.Controllers
{
    public class SubcategoryController : Controller
    {
        private readonly ISubcategoryService _subcategoryService;
        

        public SubcategoryController(ISubcategoryService subcategoryService)
        {
           _subcategoryService = subcategoryService;
        }
        public async Task<IActionResult> Index()
        {
            List<Subcategory> subcategories = new List<Subcategory>();
            subcategories = (List<Subcategory>)await _subcategoryService.GetSubcategoriesAsync();
            return View(subcategories);
        }
        public async Task<IActionResult> Create()
        {
            ViewData["categories"] = await _subcategoryService.GetCategoriesAsync();
            ViewData["categoryTypes"] = await _subcategoryService.GetCategoryTypesAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Subcategory subcategory)
        {
           
          
          /* Category category=new Category();
           category =subcategory.Category;
         */
           var types= await _subcategoryService.GetCategoryTypesAsync();
            foreach (var type in types)
            {
                if(type.Category.Id==subcategory.CategoryId)
                {
                    if (subcategory.CategoryType == null)
                    {
                        ViewBag.Msg = "Select Category Type";
                        return View();
                    }
                    else if(subcategory.CategoryType==type.Id)
                    {
                        await _subcategoryService.AddSubcategoryAsync(subcategory);
                        return RedirectToAction("Index");

                    }
                   
                    
                }
            }
          
            if(subcategory.CategoryType!=null)
            {
                ViewBag.Msg = "This Category have no Type";
              
            }
            else
            {
                await _subcategoryService.AddSubcategoryAsync(subcategory);
                return RedirectToAction("Index");
            }

            
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
