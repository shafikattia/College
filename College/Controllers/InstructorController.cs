using College.Models;
using College.Services;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    public class InstructorController : Controller
    {
        IInstructoreRepository InstructoreRep;
        public InstructorController(IInstructoreRepository _instructoreRep)
        {
            InstructoreRep = _instructoreRep;
        }

        public IActionResult DiplayAll()
        {
           return View(InstructoreRep.GetAll());
        }

        public IActionResult AddInstractore()
        {
            return View();
        }

    }
}
