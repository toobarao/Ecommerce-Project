using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WearMe.Business.Interface;
using WearMe.DataAccess.Entitities;
using WearMe.DataAccess.Migrations;
using WearMe.Presentation.Models;

namespace WearMe.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
      

        public ProductController(IProductService productService)
        {
            _productService=productService;
        }
        public async Task<IActionResult> Index()
        {
            List<ProductViewModel> viewModels=new List<ProductViewModel>();
            var products =await _productService.GetProductsAsync();
            foreach (var product in products)
            {
                ProductViewModel viewModel = new ProductViewModel();
                var decryptedBytes = EncryptionHelper.DecryptBytes(product.ImageData);
                var base64String = Convert.ToBase64String(decryptedBytes);
                
                var imageUrl = $"data:image/jpeg;base64,{base64String}";
                viewModel.product = product;
                viewModel.ImageUrl= imageUrl;
               
                viewModels.Add(viewModel);
               
              
            }
            
            return View(viewModels);
        }
        public async Task<IActionResult> Create()
        {
            ViewData["subcategories"] = await _productService.GetSubcategoriesAsync();
            ViewData["colors"]=await _productService.GetColorsAsync();
            ViewData["sizes"] = await _productService.GetSizesAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product,List<int> colors,List<int> sizes ,List<IFormFile> Files,IFormFile File)
        {
            Subcategory subcategory=new Subcategory();
            subcategory = await _productService.GetSubcategoryByIdAsync(product.Subcategory.Id);
            product.Subcategory= subcategory;
            var encryptedImages = new List<byte[]>();

            byte[] encryptedImage = null;
            if (File!=null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await File.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();

                    // Encrypt the byte array
                    var encryptedBytes = EncryptionHelper.EncryptBytes(fileBytes);

                    encryptedImage=encryptedBytes;
                    product.ImageData= encryptedImage;
                }
            }
            List<Image> images = new List<Image>();
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        var fileBytes = memoryStream.ToArray();

                        // Encrypt the byte array
                        var encryptedBytes = EncryptionHelper.EncryptBytes(fileBytes);

                        encryptedImages.Add(encryptedBytes);
                        Image image = new Image();
                        image.ImageData = encryptedBytes;
                        images.Add(image);
                    }
                }
            }
         await   _productService.AddProductAsync(product,colors,sizes,images);
            return View();
        }
        /*public IActionResult DisplayImages(int productId)
        {*/
            // Retrieve encrypted images from the database
            /*var encryptedImages = GetEncryptedImagesFromDatabase(productId);

            var imageUrls = new List<string>();

            foreach (var encryptedImage in encryptedImages)
            {
                var decryptedBytes = EncryptionHelper.DecryptBytes(encryptedImage);
                var base64String = Convert.ToBase64String(decryptedBytes);
                var imageUrl = $"data:image/jpeg;base64,{base64String}"; // Adjust MIME type as needed
                imageUrls.Add(imageUrl);
            }

            return imageUrls;*/
           /* View();
           
        }*/
        public IActionResult Details()
        {
           
            return View();
        }
    }
}
