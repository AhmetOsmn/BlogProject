using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        readonly Message2Manager messageManager = new(new EfMessage2Repository());
        Context context = new();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.Mail == userMail).Select(y => y.Id).FirstOrDefault();
            var values = messageManager.GetInboxByWriter(writerId);
            return View(values);
        }
    }
}
