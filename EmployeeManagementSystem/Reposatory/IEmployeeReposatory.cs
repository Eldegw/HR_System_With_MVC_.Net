using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Reposatory
{
    public interface IEmployeeReposatory
    {
       public void Add(Employee emp);
        public void Update(Employee emp);

        public void Delete(int id);

        public Employee GetById(int id);

        public List<Employee> GetAll();

        public void Save();

        public List<Employee> GetEmpsByDeptId(int deptid);
    }
}
