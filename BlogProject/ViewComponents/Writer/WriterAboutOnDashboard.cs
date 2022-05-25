using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly WriterManager writerManager = new(new EfWriterRepository());

        Context context = new();


        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            ViewBag.userName = userName;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();

            List<EntityLayer.Concrete.Writer> writers = writerManager.GetWriterById(writerId);
            return View(writers);
        }
    }
}
