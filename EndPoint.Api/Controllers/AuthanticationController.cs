using Persistance.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Common.Classes;
using Common.Enums;
using Application.Interfaces.FacadPatterns.Client;
using EndPoint.Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace EndPoint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthanticationController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IClientCartFacad _clientCartFacad;
        private readonly IConfiguration _configuration;
        private readonly IDataBaseContext db;

        public AuthanticationController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager
            , IClientCartFacad clientCartFacad,IConfiguration configuration,IDataBaseContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _clientCartFacad = clientCartFacad;
            _configuration = configuration;
            db = context;
        }

        ///<summary>ورود به سایت</summary>
        /// <response code="200">موفق</response>
        /// <response code="401">لطفا وارد سایت شوید.</response>
        /// <response code="400">خطایی رخ داده است.</response>
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] EndPoint.Api.ViewModels.LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (model is null || user is null)
                return BadRequest("کاربری با این مشخصات وجود ندارد.");

            var signIn = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);

            user = await db.ApplicationUsers.FirstOrDefaultAsync(u => u.UserName == model.UserName);
            if(user != null)
                return Ok(await getToken(user));

            if (!signIn.Succeeded)
                return BadRequest("نام کاربری یا کلمه عبور اشتباهست.");

            if (signIn.Succeeded)
                return Ok(await getToken(user));

            return BadRequest();
        }

        ///<summary>ثبت نام در سایت</summary>
        /// <response code="200">موفق</response>
        /// <response code="400">خطایی رخ داده است.</response>
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm]RegisterViewModel model)
        {
            var userExist = await _userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
                return StatusCode(500, "این نام کاربری موجودست.");

            var newUser = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser , RoleNames.Customer);

                int cartId;
                _clientCartFacad.CreateCart.Execute(model.UserName, out cartId);

                return Ok(new UserResponse()
                {
                      Message = "کاربر جدید اضافه شد.",
                      Token = await getToken(newUser)
                });
            }
            return BadRequest("خطایی رخ داده است.");
        }

        ///<summary>تغییر مقام کاربران</summary>
        /// <response code="200">موفق</response>
        /// <response code="401">لطفا وارد سایت شوید</response>
        /// <response code="400">خطایی رخ داده است.</response>
        [Authorize(Roles = "Owner")]
        [HttpPost("ChangeRole")]
        public async Task<IActionResult> ChangeRole([FromForm]ChangeRoleViewModel model)
        {
            var user = await _userManager.FindByNameAsync (model.UserName);
            if (user == null)
                return BadRequest("کاربری وجود ندارد.");

            await _userManager.RemoveFromRoleAsync(user, "Customer");
            await _userManager.RemoveFromRoleAsync(user, "Admin");
            await _userManager.RemoveFromRoleAsync(user, "Owner");

            var result = await _userManager.AddToRoleAsync (user, model.Role switch
            {
                Enums.Roles.Owner => RoleNames.Owner,
                Enums.Roles.Admin => RoleNames.Admin,
                Enums.Roles.Customer => RoleNames.Customer,
                _ => RoleNames.Customer,
            });

            if (result.Succeeded)
                return Ok("مقام کاربر تغییر یافت");
            return BadRequest("خطایی رخ داده است.");
        }

        ///<summary>دریافت اطلاعات کاربر فعلی </summary>
        ///<response code="200">موفق</response>
        ///<response code="401">لطفا وارد سایت شوید</response>
        ///<response code="400">خطایی رخ داده است.</response>
        [Authorize]
        [HttpGet("UserDetail")]
        public async Task<IActionResult> GetUserDetail()
        {
            var userName = HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync (userName);

            if(user is not null)
                return Ok(new EndPoint.Api.ViewModels.UserViewModel
                {
                    UserName = userName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Name = user.Name,
                    Family = user.Family,
                });

            return BadRequest();
        }

        private async Task<string> getToken(ApplicationUser user)
        {
            var claims = new List<Claim>()
                {
                    new Claim("name" , user.UserName),
                };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
                claims.Add(new Claim("role", role));

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"].ToString()));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "Mohammad",
                audience: "https://localhost:5001",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(12),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }
    }
}
