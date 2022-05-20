using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogProject.Controllers
{
    public class ContactController : Controller
    {
        readonly ContactManager contactManager = new(new EfContactRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.Status = true;
            contactManager.Add(contact);
            return RedirectToAction("Index","Blog");
        }
    }
}
