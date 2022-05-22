using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterMessageNotification: ViewComponent
    {
        readonly MessageManager messageManager = new(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            string receiverMail;
            receiverMail = "ahmet@gmail.com";
            var values = messageManager.GetInboxByWriter(receiverMail);
            return View(values);
        }
    }
}
