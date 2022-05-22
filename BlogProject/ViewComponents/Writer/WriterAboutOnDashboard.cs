using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        readonly WriterManager writerManager = new(new EfWriterRepository());
        Context context = new();

        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;
            var writerId = context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();

            List<EntityLayer.Concrete.Writer> writers = writerManager.GetWriterById(writerId);
            return View(writers);
        }
    }
}
