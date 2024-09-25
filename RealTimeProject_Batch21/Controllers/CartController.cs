using Microsoft.AspNetCore.Mvc;
using RealTimeProject_Batch21.Services;

namespace RealTimeProject_Batch21.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;

        public CartController(ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Plus(int cartId)
        {
            var cartFromDb = await _cartService.GetCartById(cartId);
            cartFromDb.Count = cartFromDb.Count+ 1;
            _cartService.UpdateCart(cartFromDb);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Minus(int cartId)
        {
            var cartFromDb = await _cartService.GetCartById(cartId);
            if(cartFromDb.Count <= 1)
            {
               _cartService.DeleteCart(cartId);
            }
            else
            {
                cartFromDb.Count = cartFromDb.Count - 1;
                _cartService.UpdateCart(cartFromDb);
            }
            return RedirectToAction(nameof(Index));
        }
        public  void Remove(int cartId) {
            _cartService.DeleteCart(cartId);
        }

        private double GetPriceBasedOnQuantity(int productId, int quantity)
        {
            ////async cancellation token and configure await usage
            //double finalPrice = 0.0;
            //var product = _productService.GetProductById(productId);
            //if(cartFromDb != null)
            //{
            //    cartFromDb.
            //}
            return 0.0;
        }

    }
}
