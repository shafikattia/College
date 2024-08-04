using College.Services;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    public class CrsResultController : Controller
    {
        ICourseResultRepository CourseResult;
        public CrsResultController(ICourseResultRepository _courseResult)
        {
            CourseResult = _courseResult;
        }

        public IActionResult DisplayAll()
        {
            return View(CourseResult.GetAll());
        }
    }
}
