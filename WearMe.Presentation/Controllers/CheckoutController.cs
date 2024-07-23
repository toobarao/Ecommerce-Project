using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using WearMe.Business.Interface;
using WearMe.DataAccess.Entitities;
using WearMe.Presentation.Models;

namespace WearMe.Presentation.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IProductService _productService;
        public CheckoutController(IProductService productService)
        {
            _productService=productService;
        }

        public async Task<IActionResult> Cart()
        {
            string cookieHeader = Request.Headers["Cookie"];
            string[] cookies = cookieHeader?.Split(';');
            string productIdsCookie = cookies.FirstOrDefault(c => c.Contains("productIds"));
            CartViewModel cartViewModel = new CartViewModel();
            if (productIdsCookie != null)
            {
                string[] cookieParts = productIdsCookie.Split('=');
                string cookieValue = cookieParts[1];
                string[] cookieValues = cookieValue?.Split(',');
                int[] productIds = cookieValues.Select(int.Parse).ToArray();
                var productCount = new Dictionary<int, int>();

                foreach (var productId in productIds)
                {
                    if (productCount.ContainsKey(productId))
                    {
                        productCount[productId]++;
                    }
                    else
                    {
                        productCount[productId] = 1;
                    }
                }
               

                List<CartProduct> cartProducts = new List<CartProduct>();

                decimal total = 0;
                foreach (var pr in productCount)
                {
                    CartProduct cartProduct = new CartProduct();
                    Product product = new Product();
                    product= await _productService.GetProductByIdAsync(pr.Key);
                    ProductViewModel productViewModel = new ProductViewModel();
                    var decryptedBytes = EncryptionHelper.DecryptBytes(product.ImageData);
                    var base64String = Convert.ToBase64String(decryptedBytes);
                    var imageUrl = $"data:image/jpeg;base64,{base64String}";
                    productViewModel.product = product;
                    productViewModel.ImageUrl = imageUrl;
                    cartProduct.ProductViewModel=productViewModel;
                    cartProduct.Quantity = pr.Value;
                    cartProduct.Price = cartProduct.Quantity * cartProduct.ProductViewModel.product.Price;
                    cartProducts.Add(cartProduct);
                    total += cartProduct.Price;
                   
                }
                cartViewModel.cartProducts = cartProducts;
                cartViewModel.Subtotal = total;

            }
          

            
          
            return View(cartViewModel);
        }
        public IActionResult Information()
        {

          
            return View();

        }
        [HttpPost]
        public IActionResult Information(InformationViewModel informationViewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Shipping");
            }
            else
            {

                return View();
            }

        }
       
        public IActionResult Shipping()
        {
            Shipping shipping = new Shipping();
            shipping.ShipTo = "Your Home";
            shipping.Contact = "Your Number";
            return View(shipping);
        }
        [HttpPost]
        public IActionResult Shipping(Shipping shipping)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Payment");
            }
            else
            {

                return View();
            }
           
        }
        public IActionResult Payment()
        {
            Shipping shipping = new Shipping();
            shipping.ShipTo = "Your Home";
            shipping.Contact = "Your Number";

            return View(shipping);
        }
        [HttpPost]
        public IActionResult Payment(string Payment)
        {

            return View();
        }
    }
}
