using EmployeeManagementSystem.Filters;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Reposatory;
using EmployeeManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementSystem.Controllers
{
       
    public class EmployeeController : Controller
    {
        IEmployeeReposatory empRepo;
        IDepartmentReposatory deptRepo;
        public EmployeeController(IEmployeeReposatory _empRepo, IDepartmentReposatory _deptRepo)
        {
            empRepo = _empRepo;
            deptRepo = _deptRepo;


        }


        public ActionResult EmpCardPartial(int id)
        {

            return PartialView("_EmpCard" , empRepo.GetById(id));
        }




        [Authorize]
        public IActionResult Index()
        {


            return View("Index", empRepo.GetAll());
        }
       
        public IActionResult Add()
        {
            ViewData["deptList"] = deptRepo.GetAll();
            return View("Add");
        }


        public IActionResult SaveAdd(Employee empfromRequest)
        {
            if (ModelState.IsValid)
            {
                if (empfromRequest.DepartmentId != 0)
                {
                    empRepo.Add(empfromRequest);
                    empRepo.Save();
                    return RedirectToAction("Index");
                }
                else
                {

                    ModelState.AddModelError("DepartmentId", "select department ");
                }


            }

                ViewBag.deptList = deptRepo.GetAll();

                return View("Add", empfromRequest);
            
        }

      
            
            
            
            
            
            
            
            
            
            
            
            
            
            public IActionResult Edit(int id)
        {
            Employee empModel = empRepo.GetById(id);

            ViewBag.deptList = deptRepo.GetAll();

            return View("Edit", empModel);
        }

        [HttpPost]
        public IActionResult SaveEdit(EmployeeEditViewModel empFromRequest, int id)
        {
           
            if(ModelState.IsValid)
            {
                Employee EmpFromDB = empRepo.GetById(id);

                EmpFromDB.Name = empFromRequest.Name;
                EmpFromDB.Salary = empFromRequest.Salary;
                EmpFromDB.Address = empFromRequest.Address;
                EmpFromDB.ImageURL = empFromRequest.ImageURL;
                EmpFromDB.DepartmentId = empFromRequest.DepartmentId;
                EmpFromDB.JobTitle = empFromRequest.JobTitle;
                EmpFromDB.Id = empFromRequest.Id;

                empRepo.Update(EmpFromDB);
                empRepo.Save();
                return RedirectToAction("Index");


               

            }
            ViewData["deptList"] = deptRepo.GetAll();

            return View("Edit", empFromRequest);

        }

        public IActionResult Details(int id)
        {

            return View("Details",empRepo.GetById(id));
        }

        public IActionResult Delete(int id)
        {
            

            return View("Delete" , empRepo.GetById(id));
        }



        public IActionResult ConfirmDelete(int id)
        {
            
            empRepo.Delete(id);
            empRepo.Save();
            return RedirectToAction("Index");


           
        }

    }
}