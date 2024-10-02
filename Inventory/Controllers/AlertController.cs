using Inventory.DB.ViewModels;
using Inventory.Service.Sevices.AlertService;
using Inventory.Service.Sevices.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Controllers
{
    public class AlertController : Controller
    {
        private readonly IAlertService _alertService;
        private readonly IProductService _productService;


        public AlertController(IAlertService alertService, IProductService productService)
        {
            _alertService = alertService;
            _productService = productService;
        }

        public IActionResult GetAll()
        {
            var alerts = _alertService.GetAll();
            return View("index", alerts);
        }
        public IActionResult GetById(int id)
        {
            var alert = _alertService.GetById(id);
            return View("GetById", alert);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var products = _productService.GetAll();

            var selectListItems = products.Select(c => new SelectListItem
            {
                Text = c.Name,
            }).ToList();

            var viewModel = new AlertViewModel
            {
                products = selectListItems,
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        //public async Task<IActionResult> Create(AlertViewModel vm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var products = _productService.GetAll();
        //        vm.products = products.Select(c => new SelectListItem
        //        {
        //        }).ToList();

        //        return View(vm);
        //    }

        //    var alert = new Alert
        //    {
        //        AlertDate = vm.AlertDate,
        //        Description = vm.Description,
        //        IsResolved = vm.IsResolved,

        //    };

        //    _alertService.Insert(alert);

        //    return RedirectToAction(nameof(GetAll));
        //}

        public Alert MakeAlert(int productID)
        {
            Alert ourAlert = new Alert();
            ourAlert.ProductID = productID;
            ourAlert.Product = _productService.GetById(productID);
            ourAlert.AlertDate = DateTime.Now;
            ourAlert.IsResolved = false;
            ourAlert.Description = $"The {ourAlert.Product.Name} Item is low, with {ourAlert.Product.StockQuantity} in the stock ";
            return ourAlert;
        }


        public IActionResult Delete(int id)
        {
            _alertService.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
