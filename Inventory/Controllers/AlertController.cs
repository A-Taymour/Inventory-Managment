using Inventory.Service.Sevices.AlertService;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class AlertController : Controller
    {
        private readonly IAlertService _alertService;


        public AlertController(IAlertService alertService)
        {
            _alertService = alertService;

        }
        
        public IActionResult GetAll()
        {
            var alerts = _alertService.GetAll();
            return View("GetAll", alerts);
        }
        public IActionResult GetById(int id)
        {
            var alert = _alertService.GetById(id);
            return View("GetById", alert);
        }


        public IActionResult Insert(Alert alert)
        {
            if (ModelState.IsValid)
            {
                _alertService.Insert(alert);
                return RedirectToAction(nameof(GetAll));
            }
            return View("Insert", alert);
        }



        public IActionResult Delete(int id)
        {
            _alertService.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
