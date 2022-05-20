using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlogProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.Status = true;
            comment.BlogId = 10;
            commentManager.Add(comment);
            return PartialView();
        }

        public PartialViewResult CommentListByBlog(int id)
        {
            List<Comment> comments = commentManager.GetAllByBlog(id);
            return PartialView(comments);
        }
    }
}
