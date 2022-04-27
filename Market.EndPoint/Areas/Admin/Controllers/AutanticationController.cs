using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using Domain.Entities.User;
using Application.Interfaces.FacadPatterns.Client;
using Common.Utilities;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AutanticationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IClientCartFacad _clientCartFacad;
        public AutanticationController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager
             , IClientCartFacad clientCartFacad)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _clientCartFacad = clientCartFacad;
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
    }
}
