using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogProject.Controllers
{
    public class AboutController : Controller
    {
        readonly AboutManager aboutManager = new(new EfAboutRepository());

        public IActionResult Index()
        {
            List<About> abouts = aboutManager.GetAll();
            return View(abouts);
        }

        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
