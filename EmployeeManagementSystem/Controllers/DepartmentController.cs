using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Reposatory;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    
    public class DepartmentController : Controller
    {
        IDepartmentReposatory DeptRepo;
        private readonly IEmployeeReposatory empRepo;

        public DepartmentController(IDepartmentReposatory deptRepo , IEmployeeReposatory EmpRepo)
        {
            DeptRepo = deptRepo;
            empRepo = EmpRepo;
        }


        public IActionResult DeptEmps()
        {
            return View("DeptEmps" , DeptRepo.GetAll());
        }

        public IActionResult GetEmpsByDeptId(int deptid)
        {
           List<Employee>emplist = empRepo.GetEmpsByDeptId(deptid);

            return Json(emplist);
        }



        public IActionResult Index()
        {
          List<Department> departmentList = DeptRepo.GetAll();
           
            return View("Index" , departmentList);
        }

        


        public IActionResult Details(int id)
        {
            Department dept = DeptRepo.GetById(id);

            return View("Details", dept);
        }


     


        public IActionResult Edit( int id)
        {
            Department dept = DeptRepo.GetById(id);

            return View("Edit" ,dept);
        }


        [HttpPost]
        public IActionResult SaveEdit(Department deptFromREquest)
        {
            if (ModelState.IsValid)
            {
                DeptRepo.Update(deptFromREquest);
                DeptRepo.Save();
                return RedirectToAction("Index");
            }


            return View("Edit" , deptFromREquest);
        }




        public IActionResult Add()
        {

            return View("Add");

        }


        [HttpPost]
        public IActionResult SaveAdd(Department newdeptfromRequest)
        {
            if (ModelState.IsValid)
            {

                DeptRepo.Add(newdeptfromRequest);
                DeptRepo.Save();
                return RedirectToAction("Index");




            }


            return View("Add" , newdeptfromRequest);
        }


        
        public IActionResult Delete(int id)
        {

            return View("Delete",DeptRepo.GetById(id));
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            
            DeptRepo.Delete(id);
            DeptRepo.Save();
            return RedirectToAction("Index");


            
        }


    }
}
