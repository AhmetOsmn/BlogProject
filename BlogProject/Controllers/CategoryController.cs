using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new(new EfCategoryRepository());
        public IActionResult Index()
        {
            var categories = categoryManager.GetAll();
            return View(categories);
        }
    }
}
