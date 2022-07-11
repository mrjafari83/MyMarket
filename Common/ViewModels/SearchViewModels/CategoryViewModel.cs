using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels.SearchViewModels
{
    public class ProductCategoryViewModel
    {
        [Display(Name = "نام دسته بندی")]
        public string CategoryName { get; set; } = "";

        [Display(Name = "نام دسته بندی والد")]
        public string ParentName { get; set; } = "ندارد";

        [Display(Name ="تعداد زیر مجموعه ها")]
        public int ChildrenCount { get; set; } = 0;
    }

    public class BlogCategoryViewModel
    {
        [Display(Name = "نام دسته بندی")]
        public string CategoryName { get; set; } = "";

        [Display(Name = "نام دسته بندی والد")]
        public string ParentName { get; set; } = "ندارد";

        [Display(Name = "تعداد زیر مجموعه ها")]
        public int ChildrenCount { get; set; } = 0;
    }
}
