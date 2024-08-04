using College.Models;
using College.ViewModel;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CorsResult = College.Models.CorsResult;

namespace College.Controllers
{
    public class TraineeCoursesController : Controller
    {
        collegecontext context = new collegecontext();
        public IActionResult Displayinformaion(int id)
        {

            // Fetch trainees with their departments

                List<CorsResult> info = context.CorsResults
                                                .Include(d=> d.Trainee).Include(d=>d.Course).Where(d => d.TranId == id).ToList();
            List<Course> infoid = context.CorsResults.Select(tc => tc.Course).ToList();
            ViewBag.COURSE = infoid;


                // Initialize the ViewModel list
                List<TraineeCoursesViewModel> traineeViewModels = info.
                    Select(t => new TraineeCoursesViewModel
                    {
                         TranieeId = t.TranId,
                        TraineeName = t.Trainee.Name,
                        CourseName = t.Course.Name,
                        Degree=t.Degree,
                      
                       
                    }).ToList();

                // Return the populated ViewModel to the view
                return View(traineeViewModels);
            }

          
    }
}
