using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        BlogManager blogManager = new(new EfBlogRepository());

        public IViewComponentResult Invoke(int id)
        {
            var values = blogManager.GetBlogListByWriter(id);
            return View(values);
        }

    }
}
