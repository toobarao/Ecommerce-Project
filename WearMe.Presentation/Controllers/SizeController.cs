using Microsoft.AspNetCore.Mvc;
using WearMe.Business.Implementation;
using WearMe.Business.Interface;
using WearMe.DataAccess.Entitities;

namespace WearMe.Presentation.Controllers
{
    public class SizeController : Controller
    {
        private readonly ISizeService _sizeService;
        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["sizes"]=await  _sizeService.GetSizesAsync();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
       
    }
}
