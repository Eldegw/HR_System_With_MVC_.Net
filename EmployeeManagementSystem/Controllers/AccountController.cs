using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            SignInManager = signInManager;
        }

        public SignInManager<ApplicationUser> SignInManager { get; }

        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRegister(RegisterViewMode registerView)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser();
                appUser.UserName = registerView.UserName;
                //appUser.PasswordHash = registerView.Password;
                appUser.Address = registerView.Address;


               IdentityResult Result =  await userManager.CreateAsync(appUser,registerView.Password);


                if (Result.Succeeded)
                {
                    //await userManager.AddToRoleAsync(appUser, "Admin");

                    await SignInManager.SignInAsync(appUser, false);

                    return RedirectToAction("Index", "Department");

                }
                foreach (var item in Result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }



            }
           
            return View("Register", registerView);
        }


        public async Task<IActionResult> SignOut()
        {
           await SignInManager.SignOutAsync();   

            return View("Login");
        }


        public IActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLogin(UserLoginViewModel userLoginView)
        {
            if (ModelState.IsValid)
            {

              ApplicationUser appUser =  await userManager.FindByNameAsync(userLoginView.UserName);

                if (appUser != null)
                {
                    bool found =  await userManager.CheckPasswordAsync(appUser, userLoginView.Password);

                    if (found)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("UserAddress", appUser.Address));

                      await SignInManager.SignInWithClaimsAsync(appUser, userLoginView.RememberMe, claims);



                        //await SignInManager.SignInAsync(appUser, userLoginView.RememberMe);
                    }
                    return RedirectToAction("Index", "Employee");

                }
                ModelState.AddModelError("", "Email Or Password Is Error");

            }


            return View("Login" , userLoginView);
        }







    }
}
