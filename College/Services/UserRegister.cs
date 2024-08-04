using College.Models;
using Microsoft.AspNetCore.Identity;

namespace College.Services
{
    public class UserRegister
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        collegecontext context;
        public UserRegister(collegecontext _context, UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> signInManager)
        {
    
        }

    }
}
