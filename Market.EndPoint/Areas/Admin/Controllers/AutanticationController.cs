using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using Domain.Entities.User;
using Application.Interfaces.FacadPatterns.Client;
using Application.Interfaces.FacadPatterns.Common;
using Common.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AutanticationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IClientCartFacad _clientCartFacad;
        private readonly ICommonCartFacad _commonCartFacad;
        public AutanticationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager
             , IClientCartFacad clientCartFacad , ICommonCartFacad commonCartFacad)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _clientCartFacad = clientCartFacad;
            _commonCartFacad = commonCartFacad;
        }

        [HttpGet]
        [Route("Admin/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Admin/Login")]
        public async Task<IActionResult> Login(LoginViwModel model)
        {
            if (_signInManager.IsSignedIn(User))
                return Redirect("/");
            var dbUser = _userManager.FindByNameAsync(model.UserName).Result;
            var userRole = _userManager.GetRolesAsync(dbUser).Result.FirstOrDefault();
            if (userRole == "Admin")
            {
                int cartId;
                cartId = _clientCartFacad.GetUserCart.Execute(model.UserName).Data.CartId;
                CookiesManager.AddCookie(HttpContext, "CartId", cartId.ToString());
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
                if (result.IsNotAllowed)
                {
                    ViewBag.LoginError = "نام کاربری یا رمز عبور اشتباهست.";
                    return ViewComponent("Login");
                }

                if (result.Succeeded)
                {
                    return Redirect("/Admin");
                }
            }


            return Redirect("/");
        }

        [Route("Admin/EditUserInfo")]
        [HttpGet]
        public IActionResult EditUserInfo()
        {
            return View();
        }

        [Route("Admin/EditUserInfo")]
        [HttpPost]
        public IActionResult EditUserInfo(string userName, string name, string family, string phoneNumber, string email)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            user.Name = name;
            user.Family = family;
            user.Email = email;
            user.UserName = userName;
            user.PhoneNumber = phoneNumber;
            var result = _userManager.UpdateAsync(user).Result;

            if (result.Succeeded)
            {
                return Redirect("/Admmin");
            }

            return Redirect("Admin/EditUserInfo");
        }

        [Route("Admin/ResetPassword")]
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [Route("Admin/ResetPassword")]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(string currentPassword, string newPassword)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var result = _userManager.ChangePasswordAsync(user, currentPassword, newPassword).Result;

            if (result.Succeeded)
                return Redirect("/Admin");
            return Redirect("/Admin/ResetPassword");
        }

        [Route("/Admin/MyPays")]
        [HttpGet]
        public IActionResult MyPays()
        {
            return View(_commonCartFacad.GetUserCartPayings.Execute(User.Identity.Name).Data);
        }
    }
}
