using BlogProject.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationsRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class WriterController : Controller
    {
        private readonly WriterManager writerManager = new(new EfWriterRepository());
        private readonly UserManager userManager = new(new EfUserRepository());

        private readonly UserManager<User> _userManager;

        public WriterController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.UserMail = userMail;
            return View();
        }

        #region EditProfile

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.Mail = values.Email;
            model.NameSurname = values.NameSurname;
            model.ImageUrl = values.ImageUrl;
            model.UserName = values.UserName;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = model.Mail;
            values.NameSurname = model.NameSurname;
            values.ImageUrl = model.ImageUrl;
            values.UserName = model.UserName;
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
        }

        #endregion

        #region AddWriter

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
            if (createWriterModel.Image != null)
            {
                var extension = Path.GetExtension(createWriterModel.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WritersImagesFiles", newImageName);
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

        #endregion


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

    }
}
