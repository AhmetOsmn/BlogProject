using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        CommentManager commentManager = new(new EfCommentRepository());
        public IActionResult Index()
        {
            var comments = commentManager.GetAllWithBlog();
            return View(comments);
        }
    }
}
