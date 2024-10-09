using Inventory.DB.ViewModels;
using Inventory.Service.Sevices.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace Inventory.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _UserService;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        public UserController(IUserService UserService, IPasswordHasher<User> passwordHasher, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _UserService = UserService;
            _passwordHasher = passwordHasher;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public List<IdentityRole> GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return roles;
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
            var roles = GetAllRoles();
            var selectRole = roles.Select(c => new SelectListItem
            {
                Value = c.Name,
                Text = c.Name,
            }).ToList();
            var viewModel = new UserViewModel
            {
                Name = User.UserName,
                Email = User.Email,
                Phone = User.PhoneNumber,
                Password = string.Empty,
                Roles = selectRole,

            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, UserViewModel viewModel)
        {

            var existingUser = _UserService.GetById(id);
            if (existingUser == null)
            {
                return NotFound("This User doesn't exist.");
            }

            existingUser.UserName = viewModel.Name;
            existingUser.Email = viewModel.Email;
            existingUser.PhoneNumber = viewModel.Phone;
            await _userManager.AddToRoleAsync(existingUser, viewModel.role);
            if (!string.IsNullOrEmpty(viewModel.Password))
            {
                existingUser.PasswordHash = _passwordHasher.HashPassword(existingUser, viewModel.Password);
            }





            _UserService.Update(existingUser);

            return RedirectToAction(nameof(GetAll));
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
