﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealTimeProject_Batch21.Models;
using RealTimeProject_Batch21.Services;
using System.Linq;
using System.Collections;
namespace RealTimeProject_Batch21.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }

        //asynchrous operations -- performance tuning Task, async and await
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var listOfProducts =  _productService.GetAllProduct();
            return View(listOfProducts);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            IEnumerable<SelectListItem> categoryNames =  _categoryService.GetAllCategory()
            .Select(u=> new SelectListItem
            {
                Text=u.Name,
                Value=u.CategoryId.ToString(),
            });
            ViewData["CategoryNames"] = categoryNames;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product,IFormFile? file)
        {
            try
            {
                ModelState.Remove("Category");
                if (product.ImageUrl == null) 
                {
                    ModelState.AddModelError("ImageUrl", "Image Url is required");
                    return View(product);
                }
                
                if(ModelState.IsValid)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    if (file != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productFolderPath = Path.Combine(wwwRootPath, @"images\product");

                        using (var fileStream = new FileStream(Path.Combine(productFolderPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        product.ImageUrl = @"images\product\" + fileName;
                    }

                    var emp = await _productService.CreateProduct(product);
                    TempData["Success"] = "Product Added Successfully";
                }
               
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
        public IActionResult GetAll()
        {
            var _categories = _productService.GetAllProduct();
            return Json(new { data = _categories });
        }
        
        #endregion
    }
}
