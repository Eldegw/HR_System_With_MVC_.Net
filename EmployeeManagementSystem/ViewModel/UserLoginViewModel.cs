using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace EmployeeManagementSystem.ViewModel
{
    public class UserLoginViewModel
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me!")]

        public bool RememberMe { get; set; }
    }
}
