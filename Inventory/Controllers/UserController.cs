using Inventory.DB.ViewModels;
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

        public IActionResult GetAll(string searchString)
        {
            var Users = _UserService.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                Users = Users.Where(x => x.Name.Contains(searchString)).ToList();
            }
            return View(Users);
        }
        public IActionResult GetById(int id)
        {
            var User = _UserService.GetById(id);
            return View(User);
        }

        [HttpGet]
        public IActionResult Insert()
        {

            return View();
        }
        [HttpPost]

        public IActionResult Insert(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var user = new User
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Password = viewModel.Password,
                    Phone = viewModel.Phone,
                    IsAdmin = viewModel.IsAdmin
                };

                _UserService.Insert(user);

                return RedirectToAction(nameof(GetAll));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var User = _UserService.GetById(id);
            if (User == null)
            {
                return NotFound("this User doesn't exist");
            }
            var viewModel = new UserViewModel
            {
                Name = User.Name,
                Email = User.Email,
                Phone = User.Phone,
                Password = User.Password,
                IsAdmin = User.IsAdmin

            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(int id, UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _UserService.GetById(id);
                if (existingUser == null)
                {
                    return NotFound("This User doesn't exist.");
                }

                existingUser.Name = viewModel.Name;
                existingUser.Email = viewModel.Email;
                existingUser.Phone = viewModel.Phone;
                existingUser.Password = viewModel.Password;
                existingUser.IsAdmin = viewModel.IsAdmin;

                _UserService.Update(existingUser);

                return RedirectToAction(nameof(GetAll));
            }
            return View(viewModel);
        }
        public IActionResult Delete(int id)
        {
            _UserService.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }

    }
}
