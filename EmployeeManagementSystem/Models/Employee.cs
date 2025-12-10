using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }


        [Required]
        [StringLength(50 , MinimumLength =4 ,ErrorMessage ="Must More Than 3 Character")]
        public string Name { get; set; }

        [Required]
        [Range(5000,100000,ErrorMessage ="Must Be More Than 5000")]
        public int Salary { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string ImageURL { get; set; }


        //[Required]
        public string? Address { get; set; }

        [ForeignKey("Department")]

      
        [Display(Name ="Department")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a department")]
        public int ? DepartmentId { get; set; }

        [ValidateNever]
        public Department Department { get; set; }
    }
}

