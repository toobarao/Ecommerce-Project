using Microsoft.AspNetCore.Mvc;

using System.Reflection;
using WearMe.Business.Implementation;
using WearMe.Business.Interface;
using WearMe.DataAccess.Entitities;



namespace WearMe.Presentation.Controllers
{
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["color"]=await _colorService.GetColorAsync();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(Color color)
        {
            
            return View();
        }
    }
}
