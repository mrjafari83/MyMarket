using System.Collections.Generic;
using Common.ViewModels;

namespace Application.Services.Admin.Products.Queries.GetProductById
{
    public class GetProductByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Brand { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string CreateDate { get; set; }
        public int VisitNumber { get; set; }
        public List<KeywordViewModel> Keywords { get; set; }
        public List<FeatureViewModel> Features { get; set; }
        public List<ColorViewModel> Colors { get; set; }
        public List<SizeViewModel> Sizes { get; set; }
        public List<InventoryAndPriceViewModel> InventoryAndPrices { get; set; }
    }
}
