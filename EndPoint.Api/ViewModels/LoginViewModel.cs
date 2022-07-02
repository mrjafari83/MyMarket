using System.ComponentModel.DataAnnotations;

namespace EndPoint.Api.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
        public string Password { get; set; }
    }
}
