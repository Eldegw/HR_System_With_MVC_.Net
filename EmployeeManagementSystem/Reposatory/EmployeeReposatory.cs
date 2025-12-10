using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Reposatory
{
    public class EmployeeReposatory : IEmployeeReposatory
    {
        ApplicationContext context;

        public EmployeeReposatory(ApplicationContext _context)
        {
            context = _context;
            
        }
        public void Add(Employee emp)
        {
           context.Add(emp);
        }

        public void Delete(int id)
        {
            Employee emp = GetById(id);
            context.Remove(emp);
        }

        public List<Employee> GetAll()
        {
          return  context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(m => m.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Employee emp)
        {
           context.Update(emp);
        }


        public List<Employee> GetEmpsByDeptId(int deptid)
        {
           return context.Employees.Where(e=>e.DepartmentId == deptid).ToList();
        }
    }
}
     