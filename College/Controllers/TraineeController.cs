using College.Models;
using College.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{

    // not  dependance injection


    //TraineeRepository Tranieeserivce = new TraineeRepository();
    //DepartmentRepository DepartmentService = new DepartmentRepository();


    public class TraineeController : Controller
    { 
        ITraineeRepository Tranieeserivce;
        IDepartmentRepository DepartmentService;

        //IOC container -->  serviceProvider
        public TraineeController(ITraineeRepository _traineerepo , IDepartmentRepository _departmentrepo  ) 
        {
            Tranieeserivce = _traineerepo;
            DepartmentService= _departmentrepo;
        }
        public IActionResult NameExisrt(String Name , int id)
        {
            Trainee TRA = Tranieeserivce.GetOne(Name);
            if (id == 0) // add
            {
                if (TRA == null)
                    return Json(true); // name not exist
                else
                    return Json(false);// name  exist
            }
            else // edit
            {
                if (TRA == null)
                {
                    return Json(true); // name not exist
                }
                else
                {
                    if (TRA.Id == id)  // name not change

                        return Json(true); // name not exist
                    else
                        return Json(false);

                }


            }
            
        }

        public IActionResult testpartial()
        {
            

            return PartialView("_ProfileCard", Tranieeserivce.GetAll());
        }
        
        public IActionResult Index()
        {
            return View(Tranieeserivce.GetAll());
        }
        [HttpPost]
        public IActionResult GetTrainee(int id)
        {
            
            return View(Tranieeserivce.GetOne(id));
        }
       
        [HttpPost]
        public ActionResult Updatedtrainee(int id)
        {
           List<Department> Dept = DepartmentService.GetAll();
            ViewBag.Departments = Dept;
            return View(Tranieeserivce.GetOne(id));

        }

        [HttpPost]
        public IActionResult Saveupdate([FromRoute]int id,Trainee train )
        {
                if (ModelState.IsValid == true)
                {
                Tranieeserivce.UpDate(id, train);
                return RedirectToAction("Index");
                }
                ViewBag.Departments = DepartmentService.GetAll();
                 return View("Updatedtrainee", train);
                }

        public IActionResult AddNewTrainee()
        {
            ViewBag.Departments = DepartmentService.GetAll();
            Trainee trin = new Trainee();
            return View(trin);
        }
        [HttpPost]
        public IActionResult SaveAdd(Trainee newtrainee)
        {
            if (ModelState.IsValid == true)
            {
                Tranieeserivce.Create(newtrainee);
                return RedirectToAction("Index");
            }
            else
            {
               
                ViewBag.Departments = DepartmentService.GetAll();
                return View("AddNewTrainee", newtrainee);
            }


        }
       
        [HttpPost]
        public IActionResult DeleteTrainee(int id)
        {
            return View(Tranieeserivce.GetOne(id));
        }
        [HttpPost]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {

            Trainee traine = Tranieeserivce.GetOne(id);
            if (traine != null)
            {
                Tranieeserivce.Delete(id);
                return RedirectToAction("Index");
            }
            return View("DeleteTrainee", traine);

        }
    }
  }

