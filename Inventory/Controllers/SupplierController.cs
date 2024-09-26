using Inventory.Models;
using Inventory.Service.Sevices.SupplierService;
using Inventory.Service.Sevices.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _SupplierService;


        public SupplierController(ISupplierService SupplierService)
        {
            _SupplierService = SupplierService;

        }

        public IActionResult GetAll()
        {
            var Suppliers = _SupplierService.GetAll();
            return View(Suppliers);
        }
        public IActionResult GetById(int id)
        {
            var Supplier = _SupplierService.GetById(id);
            return View(Supplier);
        }


        public IActionResult Insert(Supplier Supplier)
        {
            if (ModelState.IsValid)
            {
                _SupplierService.Insert(Supplier);
                return RedirectToAction(nameof(GetAll));
            }

            return View(Supplier);
        }

        public IActionResult Update(int id)
        {
            var Supplier = _SupplierService.GetById(id);
            if (Supplier == null)
            {
                return NotFound("this Supplier doesn't exist");
            }
            return View(Supplier);
        }

        [HttpPost]
        public IActionResult Update(Supplier Supplier)
        {
            if (ModelState.IsValid)
            {
                _SupplierService.Update(Supplier);
                return RedirectToAction(nameof(GetAll));
            }
            return View(Supplier);
        }


        public IActionResult Delete(int id)
        {
            _SupplierService.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }

    }
}
