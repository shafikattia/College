using College.Services;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    public class CourseController : Controller
    {
        ICoursesRepository CourseRep;
        public CourseController(ICoursesRepository _CourseRePo)
        {
           CourseRep = _CourseRePo;
        }
        public IActionResult DisplayCourse()
        {
            return View(CourseRep.GetAll());
        }
        public IActionResult AddCourse()
        {
            return View();
        }
    }
}
