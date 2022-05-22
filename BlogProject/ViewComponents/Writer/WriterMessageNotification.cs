using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterMessageNotification: ViewComponent
    {
        readonly Message2Manager messageManager = new(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            int id = 1;
            var values = messageManager.GetInboxByWriter(id);
            return View(values);
        }
    }
}
