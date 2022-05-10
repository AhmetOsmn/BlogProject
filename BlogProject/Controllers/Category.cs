using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
