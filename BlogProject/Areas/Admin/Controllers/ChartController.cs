using BlogProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<GetCategoryViewModel> categoryViewModels = new List<GetCategoryViewModel>();

            categoryViewModels.Add(new GetCategoryViewModel { categoryname = "Yazılım", blogcount = 10 });
            categoryViewModels.Add(new GetCategoryViewModel { categoryname = "Spor", blogcount = 20 });
            categoryViewModels.Add(new GetCategoryViewModel { categoryname = "Oyun", blogcount = 30 });

            return Json(new { jsonlist = categoryViewModels });
        }
    }
}
