using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.ViewModels;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Common;
using Application.Persistance.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Application.Services.Admin.User.Queries.GetUsersByFilter;
using Application.Common.ViewModels.SearchViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Application.Common.Utilities;
using Market.EndPoint.Utilities.RabbitMQ;

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
        private readonly IGetUserByFilter _getUserByFilter;
        private readonly SaveLogInFile _saveLogInFile;
        private readonly IExcelFacade _excelFacade;
        private readonly IOptionFacade _optionFacade;
        private readonly ISend _send;
        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager
            , ICartPayingFacad cartPayingFacad, ICommonCartFacad commonCartFacad,IGetUserByFilter getUserByFilter
            , ICommonCategorisFacad commonCategorisFacad, IExcelFacade excelFacade, SaveLogInFile saveLogInFile
            , IOptionFacade optionFacade, ISend send)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _cartPayingFacad = cartPayingFacad;
            _commonCartFacad = commonCartFacad;
            _getUserByFilter = getUserByFilter;
            _saveLogInFile = saveLogInFile;
            _excelFacade = excelFacade;
            _optionFacade = optionFacade;
            _send = send;
        }

        public async Task<IActionResult> Index(UserSearchVIewModel searchModel)
        {
            ViewBag.SearchKey = searchModel.SearchKey;
            ViewBag.UserRole = (int)searchModel.UserRole;
            ViewBag.SearchBy = (int)searchModel.SearchBy;

            var users = _getUserByFilter.GetUsers(searchModel).Select(u => new UserViewModel
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
            return Redirect("/Admin/Error");
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
                await _userManager.RemoveFromRoleAsync(user, "Customer");
                await _userManager.RemoveFromRoleAsync(user, "Admin");
                await _userManager.RemoveFromRoleAsync(user, "Owner");

                if (model.Owner)
                {
                    await _userManager.AddToRoleAsync(user, "Owner");
                }

                else if (model.Admin)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }

                else if (model.Customer)
                {
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

        [HttpPost]
        public async Task<IActionResult> CreateExcelConfirmed(UserSearchVIewModel searchModel)
        {
            try
            {
                var excelStatus = await _excelFacade.CreateExcelKey.Execute(searchModel, Application.Persistance.Entities.Option.SearchItemType.User);
                int excelId = excelStatus.Data;

                _send.SendToCreateExcel(excelId, "User");

                return Redirect("/Admin/Users");
            }
            catch (Exception ex)
            {
                _saveLogInFile.Log(LogLevel.Error, ex.Message, HttpContext);
                TempData["ErrorStatusCode"] = 500;
                TempData["ErrorMessage"] = "خطایی رخ داده است.";
                return View("Error");
            }
        }
    }
}
