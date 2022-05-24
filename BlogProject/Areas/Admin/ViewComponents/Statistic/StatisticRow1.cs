using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace BlogProject.Areas.Admin.ViewComponents.Statistic
{
    public class StatisticRow1 : ViewComponent
    {
        Context context = new();
        public IViewComponentResult Invoke()
        {
            ViewBag.BlogCount = context.Blogs.Count();
            ViewBag.ContactCount = context.Contacts.Count();
            ViewBag.CommentCount = context.Comments.Count();

            string apiKey = "ed97171ae2eadfdb4b7a813a9b8da3d4";
            string city = "istanbul";
            string apiConnectionString = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&mode=xml&appid=" + apiKey + "&units=metric";

            XDocument document = XDocument.Load(apiConnectionString);

            ViewBag.Temperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
    }
}

// https://api.openweathermap.org/data/2.5/weather?lat=41.0096334&lon=28.9651646&appid=ed97171ae2eadfdb4b7a813a9b8da3d4 istanbul icin hava durumu - JSON
// https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&appid=ed97171ae2eadfdb4b7a813a9b8da3d4 istanbul icin hava durumu - XML
