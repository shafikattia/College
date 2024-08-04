using College.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    [Authorize(Roles ="admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;

        }
        public IActionResult AddRole()
        
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  AddRole(RoleViewModel newrole)
        {
            if(ModelState.IsValid == true)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = newrole.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded == true) 
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(newrole);
        }
    }
}
