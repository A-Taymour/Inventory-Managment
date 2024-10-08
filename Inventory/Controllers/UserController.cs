using Inventory.DB.ViewModels;
using Inventory.Service.Sevices.UserService;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult GetAll(string searchString)
        {
            var Users = _UserService.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                Users = Users.Where(x => x.UserName.Contains(searchString)).ToList();
            }
            return View(Users);
        }
        //public IActionResult GetById(int id)
        //{
        //    var User = _UserService.GetById(id);
        //    return View(User);
        //}
		public IActionResult GetById(string id)
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
                    UserName = viewModel.Name,
                    Email = viewModel.Email,
                    PasswordHash = viewModel.Password,
                    PhoneNumber = viewModel.Phone,
                };

                _UserService.Insert(user);

                return RedirectToAction(nameof(GetAll));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            var User = _UserService.GetById(id);
            if (User == null)
            {
                return NotFound("this User doesn't exist");
            }
            var viewModel = new UserViewModel
            {
                Name = User.UserName,
                Email = User.Email,
                Phone = User.PhoneNumber,
                Password = User.PasswordHash,

            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(string id, UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _UserService.GetById(id);
                if (existingUser == null)
                {
                    return NotFound("This User doesn't exist.");
                }

                existingUser.UserName = viewModel.Name;
                existingUser.Email = viewModel.Email;
                existingUser.PhoneNumber = viewModel.Phone;

                _UserService.Update(existingUser);

                return RedirectToAction(nameof(GetAll));
            }
            return View(viewModel);
        }
        //public IActionResult Delete(int id)
        //{
        //    _UserService.Delete(id);
        //    return RedirectToAction(nameof(GetAll));
        //}
		public IActionResult Delete(string id)
		{
			_UserService.Delete(id);
			return RedirectToAction(nameof(GetAll));
		}
	}
}
