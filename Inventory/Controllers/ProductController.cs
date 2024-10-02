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
            _UserService = UserService;
        }


        [HttpGet]
        public IActionResult Create()
        {
            var categories = _CategoryService.GetAll();
            var Suppliers = _SupplierService.GetAll();
            var Users = _UserService.GetAll();

            var selectCategoryItems = categories.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.CategoryName,
            }).ToList();
            var selecSupplierItem = Suppliers.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            }).ToList();
            var selectUserItem = Users.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name,
            }).ToList();

            var viewModel = new ProductViewModel
            {
                categories = selectCategoryItems,
                Suppliers = selecSupplierItem,
                Users = selectUserItem
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(ProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var categories = _CategoryService.GetAll();
                vm.categories = categories.Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.CategoryName,
                }).ToList();
                var Supplier = _SupplierService.GetAll();
                vm.Suppliers = Supplier.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                }).ToList();
                var User = _UserService.GetAll();
                vm.Users = User.Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.Name,
                }).ToList();

                return View(vm);
            }

            var product = new Product
            {
                Name = vm.Name,
                Price = vm.Price,
                Description = vm.Description,
                CategoryID = vm.CategoryID,
                SupplierID = vm.SupplierID,
                UserID = vm.UserID,
                StockQuantity = vm.StockQuantity,
                LowStockThreshold = vm.LowStockThreshold,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt

            };

            _productService.Add(product);

            return RedirectToAction(nameof(GetAll));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var Product = _productService.GetById(id);
            if (Product == null)
            {
                return NotFound("this Product doesn't exist");
            }

            var viewModel = new ProductViewModel
            {
                Name = Product.Name,
                Description = Product.Description,
                Price = Product.Price,
                CreatedAt = Product.CreatedAt,
                UpdatedAt = Product.UpdatedAt,
                StockQuantity = Product.StockQuantity,
                LowStockThreshold = Product.LowStockThreshold,
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(int id, ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = _productService.GetById(id);
                if (existingProduct == null)
                {
                    return NotFound("This Product doesn't exist.");
                }

                existingProduct.Name = viewModel.Name;
                existingProduct.Description = viewModel.Description;
                existingProduct.Price = viewModel.Price;
                existingProduct.CreatedAt = viewModel.CreatedAt;
                existingProduct.UpdatedAt = viewModel.UpdatedAt;
                existingProduct.StockQuantity = viewModel.StockQuantity;
                existingProduct.LowStockThreshold = viewModel.LowStockThreshold;

                _productService.Update(existingProduct);

                return RedirectToAction(nameof(GetAll));
            }
            return View(viewModel);
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