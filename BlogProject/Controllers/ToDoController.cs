using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class ToDoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
