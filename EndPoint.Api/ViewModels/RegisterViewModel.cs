using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EndPoint.Api.ViewModels
{
    public class RegisterViewModel
    {
        ///<summary>نام</summary>
        [Required(ErrorMessage = "لطفا نام خود را وارد کنید")]
        public string Name { get; set; }

        ///<summary>نام خانوادگی</summary>
        [Required(ErrorMessage = "لطفا نام خانوادگی خودرا وارد کنید")]
        public string Family { get; set; }

        ///<summary>ایمیل</summary>
        [Required(ErrorMessage = "لطفا ایمیل را وراد کنید")]
        public string Email { get; set; }

        ///<summary>شماره تلفن همراه</summary>
        [Required(ErrorMessage = "لطفا شماره تلفن را وارد کنید")]
        public string PhoneNumber { get; set; }

        ///<summary>نام کاربری</summary>
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        public string UserName { get; set; }

        ///<summary>کلمه عبور</summary>
        [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
        public string Password { get; set; }
    }
}
