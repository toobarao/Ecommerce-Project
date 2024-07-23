using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WearMe.Business.Entities;
using WearMe.Business.Interface;
using WearMe.DataAccess.Entitities;

namespace WearMe.Presentation.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IUserCartService _userCartService;
        private readonly UserManager<User> _userManager;

        public CartController(UserManager<User> userManager,ICartService cartService, IUserCartService userCartService)
        {
            _userManager = userManager;
            _cartService = cartService;
            _userCartService = userCartService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string productId)
        {
           
            var cartItems = GetCartItemsFromCookies();
            var context = new CartOperationContext
            {
                ProductId = productId,
                CartItems = cartItems
            };
            _cartService.AddProductToCart(context);
            SaveCartItemsToCookies(cartItems);
           
            if(User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                var userCart = await _userCartService.GetUserCartByUserIdAsync(user);
                var serializedItems = JsonConvert.SerializeObject(cartItems);
                userCart.cartproduct = serializedItems;
                await _userCartService.UpdateUserCartAsync(userCart);}
         
            
            return Json(new { success = true, message = "Product added to cart" });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(string productId)
        {
            
            var cartItems = GetCartItemsFromCookies();
            var context = new CartOperationContext
            {
                ProductId = productId,
                CartItems = cartItems
            };
            _cartService.RemoveProductFromCart(context);
            
            SaveCartItemsToCookies(cartItems);
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                var userCart = await _userCartService.GetUserCartByUserIdAsync(user);
                var serializedItems = JsonConvert.SerializeObject(cartItems);
                userCart.cartproduct = serializedItems;
                await _userCartService.UpdateUserCartAsync(userCart);
            }
            return Json(new { success = true, message = "Product removed from cart" });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProductOnce(string productId)
        {
            var cartItems = GetCartItemsFromCookies();
            var context = new CartOperationContext
            {
                ProductId = productId,
                CartItems = cartItems
            };
            _cartService.RemoveProductOnce(context);
            SaveCartItemsToCookies(cartItems);

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                var userCart = await _userCartService.GetUserCartByUserIdAsync(user);
                var serializedItems = JsonConvert.SerializeObject(cartItems);
                userCart.cartproduct = serializedItems;
                await _userCartService.UpdateUserCartAsync(userCart);
            }
            return Json(new { success = true, message = "Product removed once from cart" });
        }

        [HttpGet]
        public IActionResult GetCartItems()
        {
            var cartItems = GetCartItemsFromCookies();
            return Json(new { success = true, items = cartItems });
        }

        private List<string> GetCartItemsFromCookies()
        {
            var cookieValue = Request.Cookies["CartItems"];
            return _cartService.GetCartItems(cookieValue);
        }

        private void SaveCartItemsToCookies(List<string> cartItems)
        {
            var options = new CookieOptions { Expires = DateTime.Now.AddDays(7) };
            var serializedItems = JsonConvert.SerializeObject(cartItems);
            Response.Cookies.Append("CartItems", serializedItems, options);
        }
    }
}
