using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BlogProject.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new(new EfMessage2Repository());
        Context context = new();

        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
            var values = message2Manager.GetInboxByWriter(writerId);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
            var values = message2Manager.GetSendboxByWriter(writerId);
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var value = message2Manager.GetById(id);
            return View(value);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 message)
        {

            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
            message.SenderId = writerId;
            message.ReceiverId = 2;
            message.Status = true;
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message2Manager.Add(message);
            return RedirectToAction("Inbox");
        }
    }
}
