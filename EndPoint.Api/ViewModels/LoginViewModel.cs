using System.ComponentModel.DataAnnotations;

namespace EndPoint.Api.ViewModels
{
    public class LoginViewModel
    {
        ///<summary>نام کاربری</summary>
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        public string UserName { get; set; }

        ///<summary>کلمه عبور</summary>
        [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
        public string Password { get; set; }
    }
}
