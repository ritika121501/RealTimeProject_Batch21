using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using RealTimeProject_Batch21.DTO;
using RealTimeProject_Batch21.LogFolder;
using RealTimeProject_Batch21.Models;
using RealTimeProject_Batch21.Services;
using System.Diagnostics;

namespace RealTimeProject_Batch21.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Requesting Weather Forecast Details...");
            LogEvents.LogToFile("Testing Log", nameof(Method), GetType().Name, "I am testing logging");
            IEnumerable<ProductViewModel> productList = _productService.GetAllProduct().ToList();
            return View(productList);
        }

        //To vist again with entity framework
        public IActionResult Details(int productId) {
            ShoppingCart cart = new ShoppingCart();
            cart.Product = new Product();
            cart.Product.ISBN = "1234";
            cart.Product.Author = "Ritika";
            
            cart.Product.Description = "I am doing testing";
            cart.Product.Price = 24.00F;
            cart.Product.Title = "Test Book";
            cart.Count = 1;
            cart.ProductId = 1004;

            return View(cart);
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
