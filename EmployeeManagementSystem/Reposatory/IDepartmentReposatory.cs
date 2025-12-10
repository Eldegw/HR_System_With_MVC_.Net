using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Reposatory
{
    public interface IDepartmentReposatory
    {
        public void Add(Department dept);
        public void Update(Department dept);
        public void Delete(int id);

        public Department GetById(int id);

        public List<Department> GetAll();

        public void Save();

    }
}
