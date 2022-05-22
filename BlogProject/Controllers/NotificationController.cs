using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager notificationManager = new(new EfNotificationRepository());
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult GetAllNotification()
        {
            var values = notificationManager.GetAll();
            return View(values);
        }
    }
}
