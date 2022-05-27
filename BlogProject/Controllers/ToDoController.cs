using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ToDoController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
