namespace Application.Services.Admin.Products.Queries.GetAllProducts
{
    public class GetAllProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Brand { get; set; }
        public int Inventory { get; set; }
        public int VisitNumber { get; set; }
    }
}
