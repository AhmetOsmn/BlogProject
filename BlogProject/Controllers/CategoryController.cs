using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new(new EfCategoryRepository());
        public IActionResult Index()
        {
            List<Category> categories = categoryManager.GetAll();
            return View(categories);
        }
    }
}
