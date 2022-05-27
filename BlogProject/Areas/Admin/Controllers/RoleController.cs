using BlogProject.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class RoleController : Controller
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleController(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList(); 
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddRole(GetRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                Role role = new Role { Name = model.Name };

                var result = await _roleManager.CreateAsync(role);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }


    }
}
