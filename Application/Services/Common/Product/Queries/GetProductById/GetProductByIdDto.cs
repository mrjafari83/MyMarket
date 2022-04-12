using System.Collections.Generic;
using Common.ViewModels;
using Application.Services.Common.Comment.Queries.GetAllCommentsByPageId;

namespace Application.Services.Common.Product.Queries.GetProductById
{
    public class GetProductByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int Inventory { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ImageViewModel> Images { get; set; }
        public List<FeatureViewModel> Features { get; set; }
        public List<SizeViewModel> Sizes { get; set; }
        public List<ColorViewModel> Colors { get; set; }
    }
}
