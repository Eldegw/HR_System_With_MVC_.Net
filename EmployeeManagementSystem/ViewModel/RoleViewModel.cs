using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.ViewModel
{
    public class RoleViewModel
    {

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
