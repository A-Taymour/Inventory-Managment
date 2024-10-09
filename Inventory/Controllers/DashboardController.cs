using Inventory.Service.Sevices.CategoryService;
using Inventory.Service.Sevices.ProductService;
using Inventory.Service.Sevices.SupplierService;
using Inventory.Service.Sevices.TransactionService;
using Inventory.Service.Sevices.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService; // Change to lowercase 'c'
        private readonly ISupplierService _supplierService; // Change to lowercase 's'
        private readonly IUserService _userService; // Change to lowercase 'u'
        private readonly ITransactionService _transactionService;

        public DashboardController(IProductService productService,
            ICategoryService categoryService,
            ISupplierService supplierService,
            IUserService userService,
            ITransactionService transactionService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
            _userService = userService;
            _transactionService = transactionService;
        }

        public IActionResult DisplayDash()
        {
            var productCount = _productService.GetAll().Count();
            var categoryCount = _categoryService.GetAll().Count();
            var usersCount = _userService.GetAll().Count();
            var transactionCount = _transactionService.GetAll().Count();
            var products = _productService.GetAll();

            // Ensure these lines are included and correct
            ViewBag.ProductNames = products.Select(p => p.Name).ToList();
            ViewBag.ProductQuantities = products.Select(p => p.StockQuantity).ToList();

            ViewBag.ProductCount = products.Count(); // Ensure to count products directly from the collection
                                                     // Other ViewBag properties...
            ViewBag.CategoryCount = categoryCount;
            ViewBag.UserCount = usersCount;
            ViewBag.SupplierCount = transactionCount;
            ViewBag.Products = products; // Changed to 'Products' for consistency

            return View();
        }
    }
}
