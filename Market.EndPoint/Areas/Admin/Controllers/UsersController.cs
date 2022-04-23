using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.ViewModels;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.Select(u => new UserViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
            }).ToList();

            foreach (var item in users)
            {
                var user = _userManager.FindByNameAsync(item.UserName).Result;
                var roleName = await _userManager.GetRolesAsync(user);
                item.RoleName = roleName.FirstOrDefault();
            }

            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string email, string userName, string password)
        {
            await _userManager.CreateAsync(new IdentityUser
            {
                Email = email,
                UserName = userName
            }, password);

            return Redirect("/Admin/Users");
        }

        [HttpGet]
        public IActionResult Delete(string userName)
        {
            var user = _userManager.FindByNameAsync(userName).Result;
            UserViewModel userViewModel = new UserViewModel()
            {
                Email = user.Email,
                UserName = user.UserName,
                Id = user.Id
            };

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Deleting(string userName)
        {
            await _userManager.DeleteAsync(await _userManager.FindByNameAsync(userName));
            return Redirect("/Admin/Users");
        }

        [HttpGet]
        public IActionResult EditUserRoles(string userName)
        {
            ViewBag.UserName = userName;
            var model = new EditUserRolesViewModel()
            {
                UserName = userName
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserRoles(EditUserRolesViewModel model)
        {
            if ((model.Admin && model.Owner) || (model.Admin && model.Customer) 
                || (model.Customer && model.Owner) || (model.Admin && model.Owner && model.Customer))
                return Redirect("/Admin/Users");

            var user = _userManager.FindByNameAsync(model.UserName).Result;
            var roles = new List<string>() { "Owner", "Admin", "Customer" };
            if (model.Owner)
            {
                if (!_roleManager.Roles.Any(r => r.Name == "Owner"))
                    await _roleManager.CreateAsync(new IdentityRole { Name = "Owner" });
                await _userManager.RemoveFromRolesAsync(user, roles);
                await _userManager.AddToRoleAsync(user, "Owner");
            }

            else if (model.Admin)
            {
                if (!_roleManager.Roles.Any(r => r.Name == "Admin"))
                    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                await _userManager.RemoveFromRolesAsync(user, roles);
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            else if (model.Customer)
            {
                if (!_roleManager.Roles.Any(r => r.Name == "Customer"))
                    await _roleManager.CreateAsync(new IdentityRole { Name = "Customer" });
                await _userManager.RemoveFromRolesAsync(user, roles);
                await _userManager.AddToRoleAsync(user, "Customer");
            }

            return Redirect("/Admin/Users");
        }
    }
}
