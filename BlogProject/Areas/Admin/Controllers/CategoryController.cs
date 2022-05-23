using BusinessLayer.Concrete;
using BusinessLayer.ValidationsRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new(new EfCategoryRepository());
        public IActionResult Index(int page= 1)
        {
            var values = categoryManager.GetAll().ToPagedList(page,10);
            return View(values);
        }

        #region AddCategory

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator validator = new();
            ValidationResult results = validator.Validate(category);

            if (results.IsValid)
            {

                category.Status = true;
                categoryManager.Add(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        #endregion
    }
}
