﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogManager = new(new EfBlogRepository());
        public IActionResult Index()
        {
            var blogs = blogManager.GetBlogListWithCategory();
            return View(blogs);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.Id = id;
            List<Blog> blog = blogManager.GetBlogById(id);
            return View(blog);
        }


    }
}
