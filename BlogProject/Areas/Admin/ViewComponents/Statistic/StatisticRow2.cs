using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProject.Areas.Admin.ViewComponents.Statistic
{
    public class StatisticRow2 : ViewComponent
    {
        Context context = new();
        public IViewComponentResult Invoke()
        {
            var latestBlog = context.Blogs.OrderByDescending(x => x.Id).Take(1).FirstOrDefault();
            ViewBag.LatestBlogTitle = latestBlog.Title;
            ViewBag.LatestBlogDate = latestBlog.CreateDate.ToShortDateString();
            return View();
        }
    }
}
