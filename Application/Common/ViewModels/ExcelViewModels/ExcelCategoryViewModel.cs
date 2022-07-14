using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ViewModels.ExcelViewModels
{
    public class ExcelCategoryViewModel
    {
        [Display(Name = "نام دسته بندی")]
        public string Name { get; set; } = "";

        [Display(Name = "نام دسته بندی والد")]
        public string ParentName { get; set; } = "ندارد";

        [Display(Name = "تعداد زیر مجموعه ها")]
        public int ChildrenCount { get; set; } = 0;
    }
}
