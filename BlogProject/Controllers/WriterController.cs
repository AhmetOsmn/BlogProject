using BlogProject.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class WriterController : Controller
    {
        private readonly WriterManager writerManager = new(new EfWriterRepository());
        private readonly UserManager userManager = new(new EfUserRepository());
        Context context = new();

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
            values.NameSurname = model.NameSurname;
            values.Email = model.Mail;
            values.ImageUrl = model.ImageUrl;
            //values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.Password);
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
        }

        #endregion

        #region AddWriter

        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }

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


        public PartialViewResult WriterNavbarPartial()
        {
            var userName = User.Identity.Name;
            var nameSurname = context.Users.Where(x => x.UserName == userName).Select(y => y.NameSurname).FirstOrDefault();
            var email = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            ViewBag.nameSurname = nameSurname;
            ViewBag.email = email;

            return PartialView();
        }

        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

    }
}
