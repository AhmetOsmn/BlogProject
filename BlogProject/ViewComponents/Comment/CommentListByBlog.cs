using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        readonly CommentManager commentManager = new(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = commentManager.GetAllByBlog(id);
            return View(values);
        }
    }
}
