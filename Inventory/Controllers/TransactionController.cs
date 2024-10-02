using Inventory.DB.ViewModels;
using Inventory.Service.Sevices.ProductService;
using Inventory.Service.Sevices.TransactionService;
using Inventory.Service.Sevices.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;



        public TransactionController(ITransactionService transactionService, IUserService userService, IProductService productService)
        {
            _transactionService = transactionService;
            _userService = userService;
            _productService = productService;
        }

        public IActionResult GetAll()
        {
            var products = _transactionService.GetAll();
            return View("GetAll", products);
        }
        public IActionResult GetById(int id)
        {
            var product = _transactionService.GetById(id);
            return View("GetById", product);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            var Products = _productService.GetAll();
            var Users = _userService.GetAll();

            var selectListItems = Products.Select(c => new SelectListItem
            {
                Text = c.Name,
            }).ToList();
            var selectListItem = Users.Select(c => new SelectListItem
            {
                Text = c.Name,
            }).ToList();

            var viewModel = new TransactionViewModel
            {
                products = selectListItem,
                Users = selectListItem
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> create(TransactionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var products = _productService.GetAll();
                vm.products = products.Select(c => new SelectListItem
                {
                }).ToList();
                var users = _userService.GetAll();
                vm.Users = users.Select(c => new SelectListItem
                {
                }).ToList();
                return View(vm);
            }

            var transaction = new Transaction
            {
                TransactionType = vm.TransactionType,
                Quantity = vm.Quantity,
                TransactionDate = vm.TransactionDate,
                UserID = vm.UserID,
                ProductID = vm.ProductID,

            };

            _transactionService.Insert(transaction);

            return RedirectToAction(nameof(GetAll));
        }

        public IActionResult Update(int id)
        {
            var product = _transactionService.GetById(id);
            if (product == null)
            {
                return NotFound("this Product doesn't exist");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _transactionService.Update(transaction);
                return RedirectToAction(nameof(GetAll));
            }
            return View(transaction);
        }


        public IActionResult Delete(int id)
        {
            _transactionService.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }

    }
}
