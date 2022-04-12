namespace Application.Services.Admin.ProductSizes.Queries.GetAllProductSizes
{
    public class GetAllProductSizesDto
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
