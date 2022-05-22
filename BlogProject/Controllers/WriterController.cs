using BlogProject.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationsRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace BlogProject.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new(new EfWriterRepository());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult WriterMail()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            Writer writer = writerManager.GetById(1);
            return View(writer);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator validator = new();
            ValidationResult result = validator.Validate(writer);
            if(result.IsValid)
            {
                writerManager.Update(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddWriter(CreateWriterModel createWriterModel)
        {
            Writer writer = new();
            if(createWriterModel.Image != null)
            {
                var extension = Path.GetExtension(createWriterModel.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WritersImagesFiles" ,newImageName);
                var stream = new FileStream(location, FileMode.Create);
                createWriterModel.Image.CopyTo(stream);
                writer.Image = newImageName;
            }
            writer.Mail = createWriterModel.Mail;
            writer.Name = createWriterModel.Name;
            writer.Password = createWriterModel.Password;
            writer.Status = true;
            writer.About = createWriterModel.About;
            writerManager.Add(writer);  
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
