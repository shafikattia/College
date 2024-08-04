using College.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace College.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> _userManager , SignInManager<IdentityUser> signInManager)
        {
            userManager = _userManager;
            this.signInManager = signInManager;
            
        }

        public IActionResult Registration()  // get
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationAccountViewModel NewAcount)  //post
        {
            if(ModelState.IsValid == true) 
            {
                IdentityUser user = new IdentityUser();
                user.UserName = NewAcount.UserName;
                user.Email = NewAcount.Email;

               IdentityResult result= await userManager.CreateAsync(user, NewAcount.Password);

                if (result.Succeeded) 
                {
                    IdentityResult roleResult = await userManager.AddToRoleAsync(user, "Student");
                    if (roleResult.Succeeded)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Trainee");
                    }
                    else
                    {
                        foreach (var error in roleResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                    
                }
                foreach (var error in result.Errors)
                {
                 ModelState.AddModelError("", error.Description);
                }
                  
               
            }
            return View(NewAcount);
        }
        [Authorize(Roles = "admin")]
        public IActionResult AddAdmin()  // get
        {
            return View("Registration");
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegistrationAccountViewModel newAccount)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = newAccount.UserName,
                    Email = newAccount.Email
                };

                IdentityResult result = await userManager.CreateAsync(user, newAccount.Password);

                if (result.Succeeded)
                {
                    IdentityResult roleResult = await userManager.AddToRoleAsync(user, "admin");
                    if (roleResult.Succeeded)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Trainee");
                    }
                    else
                    {
                        foreach (var error in roleResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View("Registration", newAccount);
        }
       
        //--------------------------------- login --------------------------
        public IActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(LoginViewModel Account)
        {
            if (ModelState.IsValid == true)
            {
                IdentityUser user = await userManager.FindByNameAsync(Account.username);
                if(user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result= await signInManager.PasswordSignInAsync(user, Account.password ,Account.ispersisite,false);
                    if (result.Succeeded) 
                    {
                        if (User.IsInRole("admin"))
                        {
                            return RedirectToAction("Index", "Trainee");
                        }

                        return RedirectToAction("Index", "Trainee");


                    }
                    else
                    {
                        ModelState.AddModelError("", "incorrect username or password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "invalid username or password");
                }
                
            }
            return View("Login", Account);
        }
        //-----------------------------------------------Logout-------------------------------------------
        public async Task <IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
 