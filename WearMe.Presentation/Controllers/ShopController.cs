using Microsoft.AspNetCore.Mvc;
using WearMe.Business.Interface;
using WearMe.Presentation.Models;

namespace WearMe.Presentation.Controllers
{
    public class ShopController : Controller
    {
        private readonly IImageService _imageService;
        private readonly IProductService _productService;
        public ShopController(IImageService imageService, IProductService productService)
        {
            _imageService = imageService;
            _productService = productService;
        }
        public async Task<IActionResult> Shop(int subcategoryId)
        {
            var products=await _productService.GetProductsBySubcategoryIdAsync(subcategoryId);
            List<ProductViewModel> viewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                ProductViewModel viewModel = new ProductViewModel();
                var decryptedBytes = EncryptionHelper.DecryptBytes(product.ImageData);
                var base64String = Convert.ToBase64String(decryptedBytes);

                var imageUrl = $"data:image/jpeg;base64,{base64String}";
                viewModel.product = product;
                viewModel.ImageUrl = imageUrl;
                viewModel.colors= (List<DataAccess.Entitities.Color>)await _productService.getProductColorById(product.Id);
                viewModel.sizes = (List<DataAccess.Entitities.Size>)await _productService.getProductSizeById(product.Id);
                viewModels.Add(viewModel);
            }

            return View(viewModels);
        }
        
        public async Task<IActionResult> ShopDetails(int productId)
        {
            var imageslist = await _imageService.GetImagesByProductIdAsync(productId);
            ImageViewModel imageviewmodel = new ImageViewModel();
            List<Images> images = new List<Images>();

            foreach (var image in imageslist)
            {
                Images image1 = new Images();
                var decryptedBytes = EncryptionHelper.DecryptBytes(image.ImageData);
                var base64String = Convert.ToBase64String(decryptedBytes);

                var imageUrl = $"data:image/jpeg;base64,{base64String}";
                image1.ImageUrl = imageUrl;

                images.Add(image1);


            }
            imageviewmodel.images = images;

            imageviewmodel.Product = await _imageService.GetProductByIdAsync(productId);
            return View(imageviewmodel);
        }

    }
}
