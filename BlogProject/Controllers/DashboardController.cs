using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProject.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context context = new();

            var userName = User.Identity.Name;
            ViewBag.userName = userName;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();

            ViewBag.v1 = context.Blogs.Count().ToString();
            ViewBag.v2 = context.Blogs.Where(x => x.WriterId == writerId).Count().ToString();
            ViewBag.v3 = context.Categories.Count().ToString();
            return View();
        }
    }
}
