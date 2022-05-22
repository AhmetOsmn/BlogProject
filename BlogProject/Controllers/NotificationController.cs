using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
