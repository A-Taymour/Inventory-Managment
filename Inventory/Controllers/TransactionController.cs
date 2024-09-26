using Inventory.Service.Sevices.ProductService;
using Inventory.Service.Sevices.TransactionService;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;


        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;

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


        public IActionResult Insert(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _transactionService.Insert(transaction);
                return RedirectToAction(nameof(GetAll));
            }
            return View("Insert", transaction);
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
