using Inventory.DB.ViewModels;
using Inventory.Models;
using Inventory.Service.Sevices.CategoryService;
using Inventory.Service.Sevices.ProductService;
using Inventory.Service.Sevices.SupplierService;
using Inventory.Service.Sevices.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _CategoryService;
        private readonly ISupplierService _SupplierService;
        private readonly IUserService _UserService;


        public ProductController(IProductService productService, ICategoryService CategoryService, ISupplierService SupplierService, IUserService UserService)
        {
            _productService = productService;
            _SupplierService = SupplierService;
            _CategoryService = CategoryService;
            _UserService= UserService;
        }


        [HttpGet]
        public IActionResult Create()
        {
            var categories = _CategoryService.GetAll(); 
            var Suppliers = _SupplierService.GetAll();  
            var Users = _UserService.GetAll();  
         
            var selectListItems = categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName, 
            }).ToList();  
            var selectListItem = Suppliers.Select(c => new SelectListItem
            {
                Text = c.Name, 
            }).ToList();
            var selectUserItem = Users.Select(c => new SelectListItem
            {
                Text = c.Name,  
            }).ToList();

            var viewModel = new CreateProductViewModel
            {
                categories = selectListItems,
                Suppliers= selectListItem, 
                Users= selectUserItem 
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(CreateProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var categories = _CategoryService.GetAll();
                vm.categories = categories.Select(c => new SelectListItem
                {
                }).ToList();
                  var Supplier = _SupplierService.GetAll();
                vm.Suppliers = Supplier.Select(c => new SelectListItem
                {
                }).ToList();
                     var User = _UserService.GetAll();
                 vm.Users = User.Select(c => new SelectListItem
               {
                 }).ToList();

                return View(vm);
            }

            var product = new Product
            {
                Name = vm.Name,
                Price = vm.Price,
                StockQuantity = vm.StockQuantity,
                LowStockThreshold = vm.LowStockThreshold,
                CategoryID = vm.CategoryID,
                SupplierID=vm.SupplierID,
                UserID = vm.UserID,
                CreatedAt=vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt
              
            };

            _productService.Add(product);

            return RedirectToAction(nameof(GetAll));
        }




        public IActionResult Update(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
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