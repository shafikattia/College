using College.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using College.ViewModel;
namespace College.Controllers
{
    public class TraineeDepartmentController : Controller
    {
        collegecontext context = new collegecontext();
       

       
        public IActionResult TraineeDepartment()
        {
            // Fetch trainees with their departments
            List<Trainee> trainees = context.Trainees
                                            .Include(t => t.Department)
                                            .ToList();

            // Initialize the ViewModel list
            List<TraineeDepartmentViewModel> traineeViewModels = trainees.
                Select(t => new TraineeDepartmentViewModel
                {
                TraineID = t.Id,
                TraineeName = t.Name,
                 departmentName = t.Department.Name,
                
            }).ToList();

            // Return the populated ViewModel to the view
            return View(traineeViewModels);
        }

        public   IActionResult searchTraineeDepartment(string searchTerm)
        {


            // Fetch trainees with their departments
            List<Trainee> trainees = context.Trainees
                                            .Include(t => t.Department).Where(t=>t.Name.Contains(searchTerm))
                                            .ToList();
            if(trainees !=null)
            {
                // Initialize the ViewModel list
                List<TraineeDepartmentViewModel> traineeViewModels = trainees.
                    Select(t => new TraineeDepartmentViewModel
                    {
                        TraineID = t.Id,
                        TraineeName = t.Name,
                        departmentName = t.Department.Name,
                       
                    }).ToList();

                // Return the populated ViewModel to the view
             return  View("TraineeDepartment", traineeViewModels);
            }
            else
            {
                 return  RedirectToAction("TraineeDepartment");
            }
          
        }


        //public IActionResult getall()
        //{


        //   List< Trainee>  tr = context.Trainees.
        //        Include(T => T.Department).ToList();

        //    //viewModel
        //   List <TraineewithCoursewithCorsresultViewModel> TCRM =
        //        new List< TraineewithCoursewithCorsresultViewModel>(); 
        //    foreach(var ItemModel in tr) 
        //    {
        //        foreach (var Item in TCRM)
        //        {
        //            Item.ID = ItemModel.Id;
        //            Item.TraineeName = ItemModel.Name;
        //            Item.departname = ItemModel.Department.Name;
        //            if(ItemModel.Department.Name == "front end")
        //            {
        //                Item.color = "red";
        //            }
        //            else
        //            {
        //                Item.color = "green";
        //            }
        //        }
        //       }

        //    return View(TCRM);
        //}
    }
}
