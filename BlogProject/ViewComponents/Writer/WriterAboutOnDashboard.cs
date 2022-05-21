using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogProject.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        readonly WriterManager writerManager = new(new EfWriterRepository());

        public IViewComponentResult Invoke()
        {
            List<EntityLayer.Concrete.Writer> writers = writerManager.GetWriterById(1);
            return View(writers);
        }
    }
}
