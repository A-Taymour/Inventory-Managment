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
        private readonly ICategoryService _CategoryService;
        private readonly ISupplierService _SupplierService;
        private readonly IUserService _UserService;
        private readonly ITransactionService _transactionService;
        public DashboardController(IProductService productService, ICategoryService CategoryService, ISupplierService SupplierService,
            IUserService UserService, ITransactionService transactionService)
        {
            _productService = productService;
            _CategoryService = CategoryService;
            _SupplierService = SupplierService;
            _UserService = UserService;
            _transactionService = transactionService;

        }

        public IActionResult DisplayDash()
        {
            var ProductCount = _productService.GetAll().Count();
            var CategoryCount = _CategoryService.GetAll().Count();
            var UsersCount = _UserService.GetAll().Count();
            var TransactionCount = _transactionService.GetAll().Count();
            var products = _productService.GetAll();

            ViewBag.ProductNames = products.Select(p => p.Name).ToList();
            ViewBag.ProductQuantities = products.Select(p => p.StockQuantity).ToList();

            ViewBag.ProductCount = ProductCount;
            ViewBag.CategoryCount = CategoryCount;
            ViewBag.UserCount = UsersCount;
            ViewBag.SupplierCount = TransactionCount;
            ViewBag.products = products;
            return View();
        }
    }
}

