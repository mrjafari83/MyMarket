using Application.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EndPoint.Api.ViewModels.Products
{
    public class CreateProductViewModel
    {
        ///<summary>نام محصول</summary>
        [Required(ErrorMessage = "لطفا یک نام انتخاب کنید.")]
        public string Name { get; set; } = "";

        ///<summary>برند محصول</summary>
        [Required(ErrorMessage = "لطفا یک برند انتخاب کنید.")]
        public string Brand { get; set; } = "";

        ///<summary>توضیحات مختصر</summary>
        [Required(ErrorMessage = "لطفا توضیحات مختصر را وارد کنید.")]
        public string ShortDescription { get; set; } = "";

        ///<summary>توضیحات</summary>
        [Required(ErrorMessage = "لطفا یک توضیحات وارد کنید.")]
        public string Description { get; set; } = "";

        ///<summary>دسته بندی</summary>
        [Required(ErrorMessage = "لطفا یک دسته بندی انتخاب کنید.")]
        public int CategoryId { get; set; } = 1383;

        ///<summary>کلمات کلیدی</summary>
        public List<KeywordViewModel> Keywords { get; set; }

        ///<summary>رنگ ها</summary>
        public List<ColorViewModelCreate> Colors { get; set; }

        ///<summary>سایزها</summary>
        public List<SizeViewModel> Sizes { get; set; }

        ///<summary>ویژگی های محصول</summary>
        public List<FeatureViewModel> Features { get; set; }

        ///<summary>موجودی و قیمت محصولات.توجه : این بخش باید بر اساس ترکیب رنگ ها و سایز ها پر شود!</summary>
        //public List<IFormFile> Images { get; set; }
        public List<InventoryAndPriceViewModelCreate> InventoryAndPrices { get; set; }
    }
}
