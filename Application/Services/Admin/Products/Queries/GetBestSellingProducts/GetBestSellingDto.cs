namespace Application.Services.Admin.Products.Queries.GetBestSellingProducts
{
    public class GetBestSellingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageSrc { get; set; }
        public int SellingCount { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Inventory { get; set; }
        public int Price { get; set; }
    }
}
