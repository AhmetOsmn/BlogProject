using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        readonly NotificationManager notificationManager = new(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = notificationManager.GetAll();
            return View(values);
        }
    }
}
