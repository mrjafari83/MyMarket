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
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

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
        private readonly IConfiguration _configuration;
        public AutanticationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager
             , IClientCartFacad clientCartFacad, ICommonCartFacad commonCartFacad, IHostingEnvironment hostingEnvironment
            , IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _clientCartFacad = clientCartFacad;
            _commonCartFacad = commonCartFacad;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        [Route("Admin/EditUserInfo")]
        [HttpGet]
        public IActionResult EditUserInfo()
        {
            return View();
        }

        [Route("Admin/EditUserInfo")]
        [HttpPost]
        public IActionResult EditUserInfo(string userName, string name, string family, string phoneNumber, string email, Microsoft.AspNetCore.Http.IFormFile image)
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
            if (user != null)
            {
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
