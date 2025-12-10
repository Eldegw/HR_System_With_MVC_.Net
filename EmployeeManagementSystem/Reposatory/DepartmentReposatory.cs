using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Reposatory
{

     
    public class DepartmentReposatory : IDepartmentReposatory
    {
        ApplicationContext context;


        public DepartmentReposatory(ApplicationContext _context)
        {
            context = _context;
            
        }

        public void Add(Department dept)
        {
          context.Add(dept);
        }

        public void Update(Department dept)
        {
           context.Update(dept);
        }

        public void Delete(int id)
        {
           Department dept = GetById(id);
               context.Remove(dept);

        }

        public List<Department> GetAll()
        {
          return context.departments.ToList();
        }

        public Department GetById(int id)
        {
          return context.departments.FirstOrDefault(c=>c.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

       
    }
}
