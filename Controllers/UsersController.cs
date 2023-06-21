using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mo3askerpro2.Models;
using mo3askerpro2.Models.viewmodels;
using System.Linq;
using System.Threading.Tasks;
//using UserManagementWithIdentity.Controllers.;


namespace UserManagementWithIdentity.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Select(user => new UserViewModel
            {
                Id = user.Id,
            
                UserName = user.UserName,
                Email = user.Email,
                Roles = _userManager.GetRolesAsync(user).Result
            }).ToListAsync();

            return View(users);
        }

        public async Task<IActionResult> Add()
        {
       

            var roles = await _roleManager.Roles.Select(r=> new RoleViewModel { RoleId=r.Id ,RoleName=r.Name}).ToListAsync();

            var viewModel = new AddUserViewModel
            {

                Roles = roles
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (!model.Roles.Any(r=>r.IsSelected))
            {
                ModelState.AddModelError("Roles", "Please Select At Least one role");
                    return View(model);
            }
            if(await _userManager.FindByEmailAsync(model.EmailAccount)!=null)
            {
                ModelState.AddModelError("Email", "Email is Already Exsist");
                return View(model);
            }
            if (await _userManager.FindByNameAsync(model.UserName) != null)
            {
                ModelState.AddModelError("UserName", "UserName is Already Exsist");
                return View(model);
            }
            var user = new ApplicationUser { UserName = model.UserName, Email = model.EmailAccount, PhoneNumber = model.phone };
            var r = await _userManager.CreateAsync(user, model.password);

            if (!r.Succeeded)
            {
                foreach (var err in r.Errors)
                {
                    ModelState.AddModelError("Roles", err.Description);

                }
                await _userManager.AddToRolesAsync(user, model.Roles.Where(r=>r.IsSelected).Select(r => r.RoleName));
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();


            var viewModel = new ProfileFormViewModel
            {
                Id = userId,
                UserName = user.UserName,
                EmailAccount = user.Email,
                phone = user.PhoneNumber
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
                return NotFound();
            var userwithSameEmail = await _userManager.FindByEmailAsync(model.EmailAccount);
            if (userwithSameEmail != null && userwithSameEmail.Id != model.Id)
            {
                ModelState.AddModelError("EmailAccount", "This Email is already assigned to anaother user");
                return View(model);
            }

            var userwithSameName = await _userManager.FindByNameAsync(model.UserName);

            if (userwithSameName != null && userwithSameName.Id != model.Id)
            {
                ModelState.AddModelError("UserName", "This UserName is already assigned to anaother user");
                return View(model);
            }

            user.UserName = model.UserName;
            user.Email = model.EmailAccount;
            user.PhoneNumber = model.EmailAccount;

            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            var roles = await _roleManager.Roles.ToListAsync();

            var viewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(role => new RoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
                return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in model.Roles)
            {
                if (userRoles.Any(r => r == role.RoleName) && !role.IsSelected)
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);

                if (!userRoles.Any(r => r == role.RoleName) && role.IsSelected)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
            }

            return RedirectToAction(nameof(Index));
        }

       
    }
}