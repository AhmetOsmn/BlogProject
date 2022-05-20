using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        readonly BlogManager blogManager = new(new EfBlogRepository());
        public IActionResult Index()
        {
            List<Blog> blogs = blogManager.GetBlogListWithCategory();
            return View(blogs);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.Id = id;
            List<Blog> blogs = blogManager.GetBlogById(id);
            return View(blogs);
        }

        public IActionResult BlogListByWriter()
        {
            List<Blog> blogs = blogManager.GetBlogListByWriter(1);
            return View(blogs);
        }


    }
}
