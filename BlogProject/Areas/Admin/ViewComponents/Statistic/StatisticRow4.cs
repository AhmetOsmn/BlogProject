using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProject.Areas.Admin.ViewComponents.Statistic
{
    public class StatisticRow4 : ViewComponent
    {
        Context context = new();

        public IViewComponentResult Invoke()
        {
            var adminDetails = context.Admins.Where(x => x.Id == 1).FirstOrDefault();
            ViewBag.AdminName = adminDetails.Name;
            ViewBag.AdminImage = adminDetails.ImageURL;
            ViewBag.AdminDesc = adminDetails.ShortDescription;
            return View();
        }
    }
}
