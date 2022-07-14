using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ViewModels.ExcelViewModels
{
    public class ExcelUserViewModel
    {
        [Display(Name = "نام")]
        public string Name { get; set; } = "ندارد";

        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; } = "ندارد";

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; } = "ندارد";

        [Display(Name = "ایمیل")]
        public string Email { get; set; } = "ندارد";

        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; } = "ندارد";
    }
}
