using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Common.ViewModels
{
    public class CreateProductViewModel
    {
        public ProductViewModel Product { get; set; }
        public List<KeywordViewModel> Keywords { get; set; }
        public List<ColorViewModelCreate> Colors { get; set; }
        public List<SizeViewModel> Sizes { get; set; }
        public List<FeatureViewModel> Features { get; set; }
        public List<InventoryAndPriceViewModelCreate> InventoryAndPrice { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
