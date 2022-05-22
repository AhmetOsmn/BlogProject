using BusinessLayer.Concrete;
using BusinessLayer.ValidationsRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        readonly BlogManager blogManager = new(new EfBlogRepository());
        readonly CategoryManager categoryManager = new(new EfCategoryRepository());
        Context context = new();

        public IActionResult Index()
        {
            List<Blog> blogs = blogManager.GetBlogListWithCategory();
            return View(blogs);
        }

        #region BlogReadAll

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.Id = id;
            List<Blog> blogs = blogManager.GetBlogById(id);
            return View(blogs);
        }

        #endregion

        #region BlogListByWriter

        public IActionResult BlogListByWriter()
        {
            var userMail = User.Identity.Name;
            var writerId = context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
            List<Blog> blogs = blogManager.GetBlogListWithCategoryByWriter(writerId);
            return View(blogs);
        }

        #endregion

        #region AddBlog

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categories = (from x in categoryManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.categoryValues = categories;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var userMail = User.Identity.Name;
            var writerId = context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();

            BlogValidator validationRules = new();
            ValidationResult results = validationRules.Validate(blog);

            if (results.IsValid)
            {

                blog.Status = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = writerId;
                blogManager.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        #endregion

        #region DeleteBlog

        public IActionResult DeleteBlog(int id)
        {
            Blog blog = blogManager.GetById(id);
            blog.Status = false;
            blogManager.Update(blog);
            //blogManager.Delete(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        #endregion

        #region EditBlog

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            Blog blog = blogManager.GetById(id);
            List<SelectListItem> categories = (from x in categoryManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.categoryValues = categories;
            return View(blog);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var userMail = User.Identity.Name;
            var writerId = context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();

            blog.WriterId= writerId;
            blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.Status = true;
            blogManager.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }

        #endregion

    }
}
