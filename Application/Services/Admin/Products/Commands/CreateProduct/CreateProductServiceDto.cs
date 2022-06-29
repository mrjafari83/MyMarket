using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Admin.Products.Commands.CreateProduct
{
    public class CreateProductServiceDto
    {
        [Required(ErrorMessage ="لطفا یک نام انتخاب کنید.")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage ="لطفا یک برند انتخاب کنید.")]
        public string Brand { get; set; } = "";

        [Required(ErrorMessage = "لطفا توضیحات مختصر را وارد کنید.")]
        public string ShortDescription { get; set; } = "";

        [Required(ErrorMessage = "لطفا یک توضیحات وارد کنید.")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "لطفا یک دسته بندی انتخاب کنید.")]
        public int CategoryId { get; set; } = 1383;

        public List<KeywordViewModel> Keywords { get; set; }
        public List<ColorViewModelCreate> Colors { get; set; }
        public List<SizeViewModel> Sizes { get; set; }
        public List<FeatureViewModel> Features { get; set; }
        //public List<IFormFile> Images { get; set; }
        public List<InventoryAndPriceViewModelCreate> InventoryAndPrices { get; set; }
    }
}
