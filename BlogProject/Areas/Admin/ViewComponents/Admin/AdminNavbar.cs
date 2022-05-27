using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Areas.Admin.ViewComponents.Admin
{
    public class AdminNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
