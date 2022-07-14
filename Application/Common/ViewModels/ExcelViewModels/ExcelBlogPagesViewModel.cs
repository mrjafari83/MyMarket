using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ViewModels.ExcelViewModels
{
    public class ExcelBlogPagesViewModel
    {
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Display(Name = "نام دسته بندی")]
        public string CategoryName { get; set; }

        [Display(Name = "توضیحات مختصر")]
        public string ShortDescription { get; set; }

        [Display(Name = "تاریخ انتشار")]
        public string CreateDate { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int VisitNumber { get; set; }
    }
}
