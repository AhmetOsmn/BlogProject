using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Areas.Admin.ViewComponents.Message
{
    public class MessageBoxNav : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
           
            return View();
        }
    }
}
