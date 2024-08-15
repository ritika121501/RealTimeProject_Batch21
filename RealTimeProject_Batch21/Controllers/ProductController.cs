using Microsoft.AspNetCore.Mvc;
using RealTimeProject_Batch21.Models;
using RealTimeProject_Batch21.Services;

namespace RealTimeProject_Batch21.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //asynchrous operations -- performance tuning Task, async and await
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var listOfProducts = await _productService.GetAllProduct();
            return View(listOfProducts);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            try
            {
                var emp = await _productService.CreateProduct(product);
                TempData["Success"] = "Product Added Successfully";
                return RedirectToAction("GetAllProducts");
            }
           catch(Exception ex)
            {
                TempData["error"] = "Duplicate Product Is Not Allowed";
                return RedirectToAction("GetAllProducts");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            Product product = await _productService.GetProductById(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product emp)
        {
            if (emp != null)
            {
                var isProductUpdated = await _productService.UpdateProduct(emp);
                if (isProductUpdated)
                {
                    return RedirectToAction("GetAllProducts");
                }
            }
            else
            {
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Product product = await _productService.GetProductById(id);
            if (product == null)
            {
                return BadRequest();
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction("GetAllProducts");
        }

        #region

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _categories = await _productService.GetAllProduct();
            return Json(new { data = _categories });
        }
        
        #endregion
    }
}
