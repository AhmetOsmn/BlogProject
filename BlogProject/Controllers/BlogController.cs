using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogManager = new(new EfBlogRepository());
        public IActionResult Index()
        {
            var blogs = blogManager.GetBlogWithCategory();
            return View(blogs);
        }
    }
}
