using BlogProject.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetWriterById(int writerid)
        {
            var writer = writerViewModels.FirstOrDefault(x => x.Id == writerid);
            var jsonWriter = JsonConvert.SerializeObject(writer);
            return Json(jsonWriter);
        }

        [HttpPost]
        public IActionResult AddWriter(GetWriterViewModel model)
        {
            writerViewModels.Add(model);
            var jsonWriters = JsonConvert.SerializeObject(model);
            return Json(jsonWriters);
        }

        public IActionResult DeleteWriter(int id)
        {
            var writer = writerViewModels.FirstOrDefault(x => x.Id == id);
            writerViewModels.Remove(writer);
            return Json(writer);
        }
        
        public IActionResult UpdateWriter(GetWriterViewModel model)
        {
            var writer = writerViewModels.FirstOrDefault(x => x.Id == model.Id);
            writer.Name = model.Name;
            var jsonWriter = JsonConvert.SerializeObject(writer);
            return Json(jsonWriter);
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writerViewModels);
            return Json(jsonWriters);
        }

        #region writerViewModels   

        public static List<GetWriterViewModel> writerViewModels = new List<GetWriterViewModel> {
            new GetWriterViewModel { Id = 1, Name = "Ayşe" },
            new GetWriterViewModel { Id = 2, Name = "Ahmet" },
            new GetWriterViewModel { Id = 3, Name = "Buse" },
        };

        #endregion
    }
}
