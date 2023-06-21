using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mo3askerpro2.Models;
using mo3askerpro2.Models.viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mo3askerpro2.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private RoleManager<IdentityRole>RoleManager;


        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager,
            RoleManager<IdentityRole>_RoleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            RoleManager = _RoleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Register(registerviewmodels model)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.EmailAccount, Email = model.EmailAccount, PhoneNumber = model.phone };
                 var r= await userManager.CreateAsync(user, model.password);

                if(r.Succeeded)
                {
                    await signInManager.SignInAsync(user,isPersistent: false);
                    await userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction("index", "Employees");
                }
                foreach (var err in r.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);


                }
            }
            return View(model);

            
        }

        [HttpPost]
        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Employees");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var r = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RemmemberMe, false);
                if (r.Succeeded)
                {
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError(string.Empty, "Invalid User/Password");
            }
            return View(model);
        }

        public IActionResult CreateRole()
        {
            return View();
        }
       


    }
}
