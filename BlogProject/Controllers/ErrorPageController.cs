using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1()
        {

            return View();
        }
    }
}
