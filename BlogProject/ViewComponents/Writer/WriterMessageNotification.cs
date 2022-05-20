using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterMessageNotification: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
