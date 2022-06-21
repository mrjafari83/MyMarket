using System.Collections.Generic;
using Common.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Admin.Products.Commands.CreateProduct
{
    public class CreateProductServiceDto
    {
        public ProductViewModel Product { get; set; }
        public List<KeywordViewModel> Keywords { get; set; }
        public List<ColorViewModel> Colors { get; set; }
        public List<SizeViewModel> Sizes { get; set; }
        public List<FeatureViewModel> Features { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<InventoryAndPriceViewModel> InventoryAndPrices { get; set; }
    }
}
