using Inventory.DB.ViewModels;
using Inventory.Models;
using Inventory.Service.Sevices.CategoryService;
using Inventory.Service.Sevices.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _CategoryService;
        

        public ProductController(IProductService productService , ICategoryService CategoryService)
        {
            _productService = productService;
            _CategoryService = CategoryService;
    }

        [HttpGet]
        public IActionResult Create()
        {
            CreateProductViewModel viewModel = new CreateProductViewModel();
            {
                viewModel.Categories = _CategoryService.GetAll();
            }
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(CreateProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = _CategoryService.GetAll();
                return View(vm);
            }

            await _productService.Insert(vm);

            return RedirectToAction(nameof(Index));
        }





        /*   public IActionResult Insert(Product product)
        {
            CreateProductViewModel viewModel = new CreateProductViewModel();
            {
                viewModel.Categories = (List<Category>)_CategoryService.GetAll();
            }
            if (ModelState.IsValid)
            {
                _productService.Insert(product);
                return RedirectToAction(nameof(GetAll));
            }
            return View("Insert", viewModel);
        }
     */
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
                return RedirectToAction(nameof(GetAll));
            }
            return View(product);
        }
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return View("GetAll", products);
        }
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            return View("GetById", product);
        }

        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }

    }
}