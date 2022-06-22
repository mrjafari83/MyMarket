using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.ViewModels;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Common;
using Domain.Entities.User;
using Microsoft.AspNetCore.Authorization;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Owner")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ICartPayingFacad _cartPayingFacad;
        private readonly ICommonCartFacad _commonCartFacad;
        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager
            , ICartPayingFacad cartPayingFacad, ICommonCartFacad commonCartFacad)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _cartPayingFacad = cartPayingFacad;
            _commonCartFacad = commonCartFacad;
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
            var result = await _userManager.CreateAsync(new ApplicationUser
            {
                Email = email,
                UserName = userName
            }, password);

            if (result.Succeeded)
                return Redirect("/Admin/Users");
            return Redirect("/Admin/Users/Create");
        }

        [HttpGet]
        public IActionResult Delete(string userName)
        {
            var user = _userManager.FindByNameAsync(userName).Result;
            if (user != null)
            {
                UserViewModel userViewModel = new UserViewModel()
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    Id = user.Id
                };

                return View(userViewModel);
            }
            return Redirect("/Admin/NotFound");
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
            if (user != null)
            {
                var roles = new List<string>() { "Owner", "Admin", "Customer" };
                if (model.Owner)
                {
                    await _userManager.RemoveFromRolesAsync(user, roles);
                    await _userManager.AddToRoleAsync(user, "Owner");
                }

                else if (model.Admin)
                {
                    await _userManager.RemoveFromRolesAsync(user, roles);
                    await _userManager.AddToRoleAsync(user, "Admin");
                }

                else if (model.Customer)
                {
                    await _userManager.RemoveFromRolesAsync(user, roles);
                    await _userManager.AddToRoleAsync(user, "Customer");
                }
            }

            return Redirect("/Admin/Users");
        }

        public async Task<IActionResult> GetUserCartPayings(string userName)
        {
            var cart = await _commonCartFacad.GetUserCartPayings.Execute(userName);
            return View(cart.Data);
        }
    }
}
