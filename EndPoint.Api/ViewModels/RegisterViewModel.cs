using System.ComponentModel.DataAnnotations;

namespace EndPoint.Api.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "لطفا ایمیل را وراد کنید")]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا شماره تلفن را وارد کنید")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "لطفا نام خود را وارد کنید")]
        public string Name { get; set; }
        [Required(ErrorMessage = "لطفا نام خانوادگی خودرا وارد کنید")]
        public string Family { get; set; }
        [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
        public string Password { get; set; }
    }
}
