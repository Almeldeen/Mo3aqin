using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mo3aqin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementWithIdentity.ViewModels;

namespace Mo3aqin.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
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
                Roles = roles.Select(role => new CheckBoxViewModel
                {
                    
                    DisplayValue = role.Name,
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
                if (userRoles.Any(r => r == role.DisplayValue) && !role.IsSelected)
                    await _userManager.RemoveFromRoleAsync(user, role.DisplayValue);

                if (!userRoles.Any(r => r == role.DisplayValue) && role.IsSelected)
                    await _userManager.AddToRoleAsync(user, role.DisplayValue);
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> AddNewUser()
        {
            var roles = await _roleManager.Roles.Select(x => new CheckBoxViewModel {  DisplayValue = x.Name }).ToListAsync();
            AddUserViewModel addUser = new AddUserViewModel()
            {
                Roles = roles
            };
            return View(addUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewUser(AddUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (!model.Roles.Any(r=> r.IsSelected))
            {
                ModelState.AddModelError("Roles", "من فضلك اختار دور واحد علي الاقل");
                return View(model);
            }
            if (await _userManager.FindByEmailAsync(model.Email)!= null)
            {
                ModelState.AddModelError("Email", "الايميل مستخدم من قبل");
                return View(model);
            }
            if (await _userManager.FindByNameAsync(model.UserName) != null)
            {
                ModelState.AddModelError("UserName", "الاسم مستخدم من قبل");
                return View(model);
            }
            var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Roles", error.Description);
                }
                return View(model);
            }
           await _userManager.AddToRolesAsync(user, model.Roles.Where(r => r.IsSelected == true).Select(r => r.DisplayValue));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditUser(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);

            if (user == null)
                return NotFound();

            var viewModel = new EditUserViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
                return NotFound();
            var userwithsameemail = await _userManager.FindByEmailAsync(model.Email);
            if (userwithsameemail!=null && userwithsameemail.Id !=model.UserId)
            {
                ModelState.AddModelError("Email", "الايميل مستخدم من قبل");
                return View(model);
            }
            var userwithsameName = await _userManager.FindByNameAsync(model.UserName);
            if (userwithsameName != null && userwithsameName.Id != model.UserId)
            {
                ModelState.AddModelError("Email", "اسم المستخدم مستخدم من قبل");
                return View(model);
            }
            user.UserName = model.UserName;
            user.Email = model.Email;
            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }

    }
}
