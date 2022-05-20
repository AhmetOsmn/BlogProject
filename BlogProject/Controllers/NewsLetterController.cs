using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class NewsLetterController : Controller
    {

        NewsLetterManager newsLetterManager = new(new EfNewsLetterRepository());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            newsLetterManager.AddNewsLetter(newsLetter);
            return PartialView();
        }
    }
}
