namespace Application.Services.Admin.CartPaying.Queries.GetProductsOfCartPaying
{
    public class ProductInCartPayingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
}
