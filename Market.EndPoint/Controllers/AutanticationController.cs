using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.ViewModels;
using Common.Utilities.MessageSender;
using Common.Utilities;
using Microsoft.AspNetCore.Identity;
using Application.Interfaces.FacadPatterns.Client;
using Application.Interfaces.FacadPatterns.Common;
using Domain.Entities.User;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Common.Classes;
using Microsoft.AspNetCore.Authorization;

namespace Market.EndPoint.Controllers
{
    public class AutanticationController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMessageSender messageSender;
        private readonly IClientCartFacad _clientCartFacad;
        private IHostingEnvironment _hostingEnvironment;
        private readonly ICommonCartFacad _commonCartFacad;
        public AutanticationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager
            , IMessageSender messageSender, IClientCartFacad clientCartFacad, IHostingEnvironment hostingEnvironment
            , ICommonCartFacad commonCartFacad)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.messageSender = messageSender;
            _clientCartFacad = clientCartFacad;
            _hostingEnvironment = hostingEnvironment;
            _commonCartFacad = commonCartFacad;
        }

        [Route("Register")]
        [HttpGet]
        public IActionResult Register(string returnUrl = "/")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            var newUser = new ApplicationUser()
            {
                Email = user.Email,
                UserName = user.UserName,
            };
            var result = await userManager.CreateAsync(newUser, user.Password);
            if (result.Succeeded)
            {
                //var confirmationEmailToken = userManager.GenerateEmailConfirmationTokenAsync(newUser);
                //var emailMessage = Url.Action("ConfirmEmail", "Autantication" ,
                //new { username = newUser.UserName, token = confirmationEmailToken } , Request.Scheme);
                //await messageSender.SendAsync(user.Email, "تایید ایمیل", emailMessage, false);
                await userManager.AddToRoleAsync(newUser, RoleNames.Customer);
                int cartId;
                _clientCartFacad.CreateCart.Execute(user.UserName, out cartId);
                CookiesManager.AddCookie(HttpContext, "CartId", cartId.ToString());
                await signInManager.PasswordSignInAsync(user.UserName, user.Password, false, true);
                return Json(true);
            }
            return Json(false);
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            if (signInManager.IsSignedIn(User))
                return Redirect("/");

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViwModel user)
        {
            if (signInManager.IsSignedIn(User))
                return Redirect("/");

            var dbUser = userManager.FindByNameAsync(user.UserName).Result;
            var userRole = userManager.GetRolesAsync(dbUser).Result.FirstOrDefault();
            if(userRole == RoleNames.Customer)
            {
                int cartId;
                cartId = _clientCartFacad.GetUserCart.Execute(user.UserName).Data.CartId;
                CookiesManager.AddCookie(HttpContext, "CartId", cartId.ToString());
                var result = await signInManager.PasswordSignInAsync(user.UserName, user.Password, user.RememberMe, true);
                if (result.IsNotAllowed)
                {
                    ViewBag.LoginError = "نام کاربری یا رمز عبور اشتباهست.";
                    return ViewComponent("Login");
                }

                if (result.Succeeded)
                {
                    return Json(true);
                }
            }


            return Json(false);
        }

        [Route("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout(string returnUrl = "")
        {
            await signInManager.SignOutAsync();
            if (returnUrl != "" && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> ConfirmEmail(string userName, string token)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(token))
                return Redirect("/");

            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
                return Redirect("/");

            await userManager.ConfirmEmailAsync(user, token);
            return Redirect("/");
        }

        [Route("Dashboard")]
        [Authorize]
        public IActionResult Dashboard()
        {
            if (signInManager.IsSignedIn(User))
                return View();
            return Redirect("/");
        }

        [Route("EditUser")]
        [Authorize]
        [HttpGet]
        public IActionResult EditUserInfo()
        {
            return View();
        }

        [Route("EditUser")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditUserInfo(EditUserViewModel model)
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            user.Name = model.Name;
            user.Family = model.Family;
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.PhoneNumber = model.PhoneNumber;

            if (model.Image != null)
            {
                FileUploader.Delete(user.ProfileImageSrc);
                user.ProfileImageSrc = FileUploader.Upload(model.Image, _hostingEnvironment, "Users/" + model.UserName);
            }

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
                return Json(true);

            return Json(false);
        }

        [Route("ResetPassword")]
        [Authorize]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [Route("ResetPassword")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ResetPassword(string currentPassword = "", string newPassword = "")
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            var result = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (result.Succeeded)
                return Json(true);

            return Json(false);
        }

        [Route("MyPays")]
        [Authorize]
        public IActionResult MyPays()
        {
            return View(_commonCartFacad.GetUserCartPayings.Execute(User.Identity.Name).Data);
        }
    }
}
