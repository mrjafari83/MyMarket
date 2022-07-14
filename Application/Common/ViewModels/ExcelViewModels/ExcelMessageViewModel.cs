using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ViewModels.ExcelViewModels
{
    public class ExcelMessageViewModel
    {
        [Display(Name="نام ")]
        public string Name { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "وبسایت")]
        public string Website { get; set; }

        [Display(Name = "متن پیام")]
        public string Text { get; set; }
    }
}
