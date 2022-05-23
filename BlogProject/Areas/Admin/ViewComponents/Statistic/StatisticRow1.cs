using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProject.Areas.Admin.ViewComponents.Statistic
{
    public class StatisticRow1 : ViewComponent
    {
        Context context = new();  
        public IViewComponentResult Invoke()
        {
            ViewBag.BlogCount = context.Blogs.Count();
            ViewBag.ContactCount = context.Contacts.Count();    
            ViewBag.CommentCount = context.Comments.Count();
            return View();
        }
    }
}
