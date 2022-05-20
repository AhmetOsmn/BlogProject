using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class AboutController : Controller
    {
        readonly AboutManager aboutManager = new(new EfAboutRepository());

        public IActionResult Index()
        {
            var values = aboutManager.GetAll();
            return View(values);
        }

        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
