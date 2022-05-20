using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult WriterMail()
        {
            return View();
        }
    }
}
