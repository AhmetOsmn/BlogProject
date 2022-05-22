using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new(new EfMessage2Repository());
        public IActionResult InBox()
        {
            int id = 1;
            var values = message2Manager.GetInboxByWriter(id);
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var value = message2Manager.GetById(id);
            return View(value);
        }
    }
}
