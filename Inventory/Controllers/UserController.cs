using Inventory.Service.Sevices.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _UserService;


        public UserController(IUserService UserService)
        {
            _UserService = UserService;

        }

        public IActionResult GetAll()
        {
            var Users = _UserService.GetAll();
            return View(Users);
        }
        public IActionResult GetById(int id)
        {
            var User = _UserService.GetById(id);
            return View(User);
        }


        public IActionResult Insert(User User)
        {
            if (ModelState.IsValid)
            {
                _UserService.Insert(User);
                return RedirectToAction(nameof(GetAll));
            }
       
            return View(User);
        }

        public IActionResult Update(int id)
        {
            var User = _UserService.GetById(id);
            if (User == null)
            {
                return NotFound("this User doesn't exist");
            }
            return View(User);
        }

        [HttpPost]
        public IActionResult Update(User User)
        {
            if (ModelState.IsValid)
            {
                _UserService.Update(User);
                return RedirectToAction(nameof(GetAll));
            }
            return View(User);
        }


        public IActionResult Delete(int id)
        {
            _UserService.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }

    }
}
