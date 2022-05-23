using BlogProject.Areas.Admin.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportBlogListDynamicExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int rowIndex= 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(rowIndex, 1).Value = item.Id; 
                    worksheet.Cell(rowIndex, 2).Value = item.Title;
                    worksheet.Cell(rowIndex, 3).Value = item.CreateDate.ToShortDateString();
                    worksheet.Cell(rowIndex, 4).Value = item.Status == true ? "aktif" : "pasif";
                    rowIndex++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openclmformats-officedocument.spreadsheetml.sheet", "BlogListesi.xlsx");
                }

            }
        }

        public List<GetBlogsViewModel> GetBlogList()
        {
            List<GetBlogsViewModel> getBlogsViewModels = new List<GetBlogsViewModel>();
            using(var context = new Context())
            {
                getBlogsViewModels = context.Blogs.Select(x => new GetBlogsViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    CreateDate = x.CreateDate,
                    Status = x.Status,
                }).ToList();
            }

            return getBlogsViewModels;
        }

        public IActionResult BlogListToExcel()
        {
            return View();
        }
    }
}
