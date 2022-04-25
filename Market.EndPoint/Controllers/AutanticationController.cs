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

namespace Market.EndPoint.Controllers
{
    public class AutanticationController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IMessageSender messageSender;
        private readonly IClientCartFacad _clientCartFacad;
        public AutanticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager
            , IMessageSender messageSender, IClientCartFacad clientCartFacad)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.messageSender = messageSender;
            _clientCartFacad = clientCartFacad;
        }

        [Route("Register")]
        [HttpGet]
        public IActionResult Register(string returnUrl = "")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user, string returnUrl = "")
        {
            var newUser = new IdentityUser()
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

                await signInManager.PasswordSignInAsync(user.UserName, user.Password, false, true);
            }

            int cartId;
            _clientCartFacad.CreateCart.Execute(user.UserName, out cartId);
            CookiesManager.AddCookie(HttpContext, "CartId", cartId.ToString());


            if (returnUrl != "" && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return Redirect(returnUrl);
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            if (signInManager.IsSignedIn(User))
                return Redirect("/");

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViwModel user, string returnUrl = "")
        {
            if (signInManager.IsSignedIn(User))
                return Redirect("/");

            ViewBag.ReturnUrl = returnUrl;
            int cartId;
            cartId = _clientCartFacad.GetUserCart.Execute(User.Identity.Name).Data.CartId;
            CookiesManager.AddCookie(HttpContext, "CartId", cartId.ToString());
            var result = await signInManager.PasswordSignInAsync(user.UserName, user.Password, user.RememberMe, true);
            if (result.IsNotAllowed)
            {
                ViewBag.LoginError = "نام کاربری یا رمز عبور اشتباهست.";
                return ViewComponent("Login");
            }

            if (result.Succeeded)
            {
                if (returnUrl != "")
                    return Redirect(returnUrl);
                return Redirect("/");
            }

            return Redirect("/");
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout(string returnUrl = "")
        {
            await signInManager.SignOutAsync();
            if (returnUrl != "" && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return Redirect("/");
        }

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
        public IActionResult Dashboard()
        {
            return View();
        }

        [Route("EditUser")]
        public IActionResult EditUserInfo()
        {
            return View();
        }

        [Route("RestPassword")]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [Route("RestPassword")]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(string currentPassword = "", string newPassword = "")
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            var result = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (result.Succeeded)
                return Redirect("/Dashboard");

            return Redirect("/RestPassword");
        }
    }
}
