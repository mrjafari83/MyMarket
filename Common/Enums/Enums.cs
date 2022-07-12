using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public class Enums
    {
        public enum CategoryType
        {
            Product,
            BlogPage
        }

        public enum ProductsFilter
        {
            [Display(Name ="جدیدترین")]
            Newest = 0,
            [Display(Name = "قدیمی ترین")]
            Oldest = 1,
            [Display(Name = "بیشترین بازدید")]
            MostViewed =2 ,
            [Display(Name = "بیشترین فروش")]
            MostSelled =3,
            [Display(Name = "کمترین بازدید")]
            LessViewed = 4,
            [Display(Name = "کمترین خرید")]
            LessSelled = 5
        }

        public enum BlogPagesFilter
        {
            [Display(Name = "جدیدترین")]
            Newest = 0,
            [Display(Name = "قدیمی ترین")]
            Oldest = 1,
            [Display(Name = "بیشترین بازدید")]
            MostViewed = 2,
            [Display(Name = "کمترین بازدید")]
            LessViewed = 3,
        }

        public enum CategoriesFilter
        {
            Non,
            ForPagesList,
            ForCategoriesList,
            Menu
        }

        public enum PageFilterCategory{
            [Display(Name = "نام")]
            Name = 0,
            [Display(Name = "برند")]
            Brand = 1,
            [Display(Name = "نام دسته بندی")]
            CategoryName = 2
        }

        public enum Status
        {
            Created = 0,
            SendToQueue = 1,
            ReciveFromQueue = 2,
            ExcelCreated = 3,
            ThrowExeption = 4
        }

        public enum Roles
        {
            [Display(Name = "مشتری")]
            Customer = 0,
            [Display(Name = "ادمین")]
            Admin = 1,
            [Display(Name = "مدیریت")]
            Owner = 2
        }

        public enum MesssagesFilter
        {
            [Display(Name = "نام")]
            Name = 0,
            [Display(Name = "ایمیل")]
            Email = 1,
            [Display(Name = "وبسایت")]
            Website = 2,
            [Display(Name = "متن پیام")]
            Text = 3
        }
    }
}
