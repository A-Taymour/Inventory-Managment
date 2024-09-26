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
            var products = _productService.GetAllProducts();
            return View(products); 
        }
        public IActionResult GetProduct(int id) { 
            var product = _productService.GetProductById(id);
            return View(product);
        }


        public IActionResult Insert(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.InsertProduct(product);
                return RedirectToAction(nameof(GetAllProducts));
            }
            return View("Insert", product);
        }

        public IActionResult Update(int id)
        {
            var employee = _productService.GetProductById(id);
            if (employee == null)
            {
                return NotFound("this employee doesn't exist");
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(product);
                return RedirectToAction(nameof(GetAllProducts));
            }
            return View(product);
        }


        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction(nameof(GetAllProducts));
        }

    }
}