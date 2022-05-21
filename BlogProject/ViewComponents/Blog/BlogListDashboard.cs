using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        BlogManager blogManager = new(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
    }
}
