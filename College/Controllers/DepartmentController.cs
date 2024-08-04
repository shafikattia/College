using College.Models;
using College.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace College.Controllers
{
    public class DepartmentController : Controller
    {
        //DepartmentRepository DepartmentService = new DepartmentRepository();
        //TraineeRepository Traineeservice = new TraineeRepository();



        ITraineeRepository Traineeservice;
        IDepartmentRepository DepartmentService;
        public DepartmentController(ITraineeRepository _Traineerepo , IDepartmentRepository _Departmentrepo ) 
        {
            Traineeservice = _Traineerepo;
            DepartmentService = _Departmentrepo;

        }
        public IActionResult NameExisrt(String Name, int id)
        {
            Department dep = DepartmentService.GetOne(Name);
            if (id == 0) // add
            {
               
                if (dep == null)
                    return Json(true); // name not exist
                else
                    return Json(false);// name  exist
            }

            else // edit
            {
                if (dep == null)
                {
                    return Json(true); // name not exist
                }
                else
                {
                    if (dep.Id == id)  // name not change

                        return Json(true); // same name
                    else
                        return Json(false);

                }


            }

        }
        public IActionResult Deptinfo()
        {
            return View(DepartmentService.GetAll());
        }
        public ActionResult Addnewdept()
        {
            Department dept = new Department();
            return View(dept);

        }
        [HttpPost]
        public IActionResult SaveAdd(Department Newdept)
        {
            if (Newdept.Name != null && Newdept.Manager != null)
            {
                DepartmentService.Create(Newdept);
                return RedirectToAction("Deptinfo");  
            }
            
            return View("Addnewdept", Newdept);
            }
        [HttpPost]
        public IActionResult updatedept(int id) 
        {
            List<Department> Dept = DepartmentService.GetAll();
            ViewBag.Departments = Dept;
            Department dept = DepartmentService.GetOne(id);
            return View(dept);
        }
        [HttpPost]
        public IActionResult saveupdate([FromRoute] int id, Department newdept)
        {
           
            if (ModelState.IsValid == true )
            {
                DepartmentService.UpDate(id, newdept);   
                return RedirectToAction("Deptinfo");
            }
            return View("updatedept", newdept);
        }
        [HttpPost]
        public IActionResult Deletedept(int id)
        {

            Department dept = DepartmentService.GetOne(id);
            return View(dept);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed([FromRoute]int id)
        {
           
            Department dept = DepartmentService.GetOne(id);
            if (dept != null)
            {
                DepartmentService.Delete(id);
                return RedirectToAction("Deptinfo");
            }
            return View("Deletedept", dept);
              
        }
        [HttpPost]
        public IActionResult DepartmentTrainee(int id) 
        {
            List<Trainee> depttraine = Traineeservice.GetAll(id);
            return View(depttraine);

        }

            
    }

}
      



       
     



