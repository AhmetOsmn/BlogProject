using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProject.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context contex = new();
            ViewBag.v1 = contex.Blogs.Count().ToString();
            ViewBag.v2 = contex.Blogs.Where(x => x.WriterId == 1).Count().ToString();
            ViewBag.v3 = contex.Categories.Count().ToString();
            return View();
        }
    }
}
