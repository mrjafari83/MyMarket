using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace EndPoint.Api.ViewModels
{
    public class ChangeRoleViewModel
    {
        ///<summary>نام کاربری</summary>
        [Required(ErrorMessage ="لطفا نام کاربری را وارد کنید")]
        public string UserName { get; set; }

        ///<summary>انتخاب مقام جدید</summary>
        [Required(ErrorMessage ="لطفا یک مقام جدید انتخاب کنید")]
        public Enums.Roles Role { get; set; }
    }
}
