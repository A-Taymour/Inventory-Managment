using Inventory.Models;
using Inventory.Service.Sevices;
using Inventory.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        

        public ProductController(IProductService productService)
        {
            _productService = productService;
            
        }

        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAll();
            return View(products); 
        }
        public IActionResult GetProduct(int id) { 
            var product = _productService.GetById(id);
            return View(product);
        }


        public IActionResult Insert(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Insert(product);
                return RedirectToAction(nameof(GetAllProducts));
            }
            return View("Insert", product);
        }

        public IActionResult Update(int id)
        {
            var product = _productService.GetById(id);
            if ( product == null)
            {
                return NotFound("this Product doesn't exist");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                return RedirectToAction(nameof(GetAllProducts));
            }
            return View(product);
        }


        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction(nameof(GetAllProducts));
        }

    }
}