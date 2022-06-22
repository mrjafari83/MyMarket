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
using Microsoft.AspNetCore.Hosting;
using Common.Classes;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class AutanticationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IClientCartFacad _clientCartFacad;
        private readonly ICommonCartFacad _commonCartFacad;
        private readonly IHostingEnvironment _hostingEnvironment;
        public AutanticationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager
             , IClientCartFacad clientCartFacad , ICommonCartFacad commonCartFacad , IHostingEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _clientCartFacad = clientCartFacad;
            _commonCartFacad = commonCartFacad;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Route("Admin/Register")]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Admin/Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string userName , string email , string password)
        {
            var newUser = new ApplicationUser()
            {
                Email = email,
                UserName = userName,
            };
            var result = await _userManager.CreateAsync(newUser, password);
            if (result.Succeeded)
            {
                //var confirmationEmailToken = userManager.GenerateEmailConfirmationTokenAsync(newUser);
                //var emailMessage = Url.Action("ConfirmEmail", "Autantication" ,
                //new { username = newUser.UserName, token = confirmationEmailToken } , Request.Scheme);
                //await messageSender.SendAsync(user.Email, "تایید ایمیل", emailMessage, false);
                await _userManager.AddToRoleAsync(newUser, RoleNames.Owner);
                int cartId;
                _clientCartFacad.CreateCart.Execute(userName, out cartId);
                CookiesManager.AddCookie(HttpContext, "CartId", cartId.ToString());
                await _signInManager.PasswordSignInAsync(userName, password, false, true);
                return Redirect("/Admin");
            }

            return Redirect("/Admin/Register");
        }

        [HttpGet]
        [Route("Admin/Login")]
        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl = "")
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Admin/Login")]
        public async Task<IActionResult> Login(LoginViwModel model)
        {
            if (_signInManager.IsSignedIn(User))
                return Redirect("/");
            var dbUser = _userManager.FindByNameAsync(model.UserName).Result;
            var userRole = _userManager.GetRolesAsync(dbUser).Result.FirstOrDefault();
            if (userRole != null && (userRole == "Admin" || userRole == "Owner"))
            {
                int cartId;
                cartId = _clientCartFacad.GetUserCart.Execute(model.UserName).Result.Data.CartId;
                CookiesManager.AddCookie(HttpContext, "CartId", cartId.ToString());
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
                if (result.IsNotAllowed)
                {
                    ViewBag.LoginError = "نام کاربری یا رمز عبور اشتباهست.";
                    return ViewComponent("Login");
                }

                if (result.Succeeded)
                {
                    if (model.ReturnUrl == "" || model.ReturnUrl == null)
                        return Redirect("/Admin");
                    return Redirect(model.ReturnUrl);
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
        public IActionResult EditUserInfo(string userName, string name, string family, string phoneNumber, string email , Microsoft.AspNetCore.Http.IFormFile image)
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                user.Name = name;
                user.Family = family;
                user.Email = email;
                user.UserName = userName;
                user.PhoneNumber = phoneNumber;

                if (image != null)
                {
                    FileUploader.Delete(user.ProfileImageSrc);
                    user.ProfileImageSrc = FileUploader.Upload(image, _hostingEnvironment, "Users/" + userName).Result;
                }

                var result = _userManager.UpdateAsync(user).Result;

                if (result.Succeeded)
                {
                    return Json(true);
                }

                return Json(false);
            }
            return Redirect("/Admin");
        }

        [Route("Admin/ResetPassword")]
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [Route("Admin/ResetPassword")]
        [HttpPost]
        public IActionResult ResetPassword(string currentPassword, string newPassword)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            if(user != null) {
                var result = _userManager.ChangePasswordAsync(user, currentPassword, newPassword).Result;

                if (result.Succeeded)
                    return Json(true);
            }
            return Json(false);
        }

        [Route("/Admin/MyPays")]
        [HttpGet]
        public async Task<IActionResult> MyPays()
        {
            var cart = await _commonCartFacad.GetUserCartPayings.Execute(User.Identity.Name);
            return View(cart.Data);
        }
    }
}
