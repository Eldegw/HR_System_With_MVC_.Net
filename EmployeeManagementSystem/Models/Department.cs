using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Department 
    {
        public int Id { get; set; }

        [Required]
        
        public string Name { get; set; }


        [Required]
        [MinLength(4 , ErrorMessage ="Should be 4 Character at Least")]
        [Display(Name = "Manager Name")]
        public string? ManagerName { get; set; }

        public List<Employee>? Emps { get; set; }

    }
}
