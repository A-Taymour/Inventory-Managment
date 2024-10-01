using Inventory.DB.ViewModels;
using Inventory.Service.Sevices.CategoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _CategoryService;


        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;

        }
        [HttpGet]
        public IActionResult Insert()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Insert(CategoryProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
              
                var category = new Category
                {
                    CategoryName = viewModel.CategoryName
                };

                
                _CategoryService.Insert(category);
               
                return RedirectToAction(nameof(GetAll));
            }

         
            return View(viewModel);
        }







        public IActionResult GetAll()
        {
            var categories = _CategoryService.GetAll();
            return View(categories);
        }
        public IActionResult GetById(int id)
        {
            var category = _CategoryService.GetById(id);
            return View("GetById", category);
        }


     /*   public IActionResult Insert(Category category)
        {
            if (ModelState.IsValid)
            {
                _CategoryService.Insert(category);
                return RedirectToAction(nameof(GetAll));
            }
            return View(category);
        }
     */
        public IActionResult Update(int id)
        {
            var category = _CategoryService.GetById(id);
            if (category == null)
            {
                return NotFound("this Category doesn't exist");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                _CategoryService.Update(category);
                return RedirectToAction(nameof(GetAll));
            }
            return View(category);
        }


        public IActionResult Delete(int id)
        {
            _CategoryService.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }

    }
}

