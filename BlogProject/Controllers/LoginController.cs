using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer writer)
        {
            Context context = new();

            var dataValue = context.Writers.FirstOrDefault(x => x.Mail == writer.Mail && x.Password == writer.Password);

            if (dataValue != null)
            {
                List<Claim> claims = new List<Claim>
               {
                   new Claim(ClaimTypes.Name, writer.Mail),
               };

                ClaimsIdentity userIdentity = new(claims, "a");
                ClaimsPrincipal principal = new(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            }

        }
    }
}
