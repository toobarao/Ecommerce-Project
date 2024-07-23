using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WearMe.Business.Implementation;
using WearMe.Business.Interface;
using WearMe.DataAccess.Entitities;
using WearMe.Presentation.Models;

namespace WearMe.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryTypeService _categoryTypeService;
     
        public HomeController(ICategoryTypeService categoryTypeService)
        {
            
            _categoryTypeService = categoryTypeService;
           
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = new List<Category>();
            categories= (List<Category>)await _categoryTypeService.GetCategoriesAsync();
            foreach (var category in categories)
            {
                var categorytype =await  _categoryTypeService.GetCategoryTypesByCategoryAsync(category.Id);
                if(categorytype.Count()==0)
                {
                    category.Subcategories = (List<Subcategory>)await _categoryTypeService.GetSubcategoriesByCategoryAsync(category.Id);
                }
                else
                {
                    category.CategoryTypes = (List<CategoryType>)await _categoryTypeService.GetCategoryTypesByCategoryAsync(category.Id);
                    foreach (var  categoryType in category.CategoryTypes)
                    {
                        categoryType.Subcategories= (List<Subcategory>)await _categoryTypeService.GetSubcategoriesByCategoryTypeAsync(categoryType.Id);
                    }
                }
            }

           
           
            return View(categories);
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
