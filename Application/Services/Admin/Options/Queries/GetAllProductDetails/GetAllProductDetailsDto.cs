namespace Application.Services.Admin.Options.Queries.GetAllProductDetails
{
    public class GetAllProductDetailsDto
    {
        public string Name { get; set; } = "";
        public string CategoryName { get; set; } = "";
        public string Brand { get; set; } = "";
        public int Price { get; set; } = 0;
        public int Inventory { get; set; } = 0;
        public string Color { get; set; } = "";
        public string Size { get; set; } = "";
        public int SellsCount { get; set; } = 0;
        public int VisitNumber { get; set; } = 0;
    }
}
