﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {

        BlogManager blogManager = new(new EfBlogRepository());

        public IActionResult Index()
        {
            var blogs = blogManager.GetBlogListWithCategory();
            return View(blogs);
        }
    }
}
