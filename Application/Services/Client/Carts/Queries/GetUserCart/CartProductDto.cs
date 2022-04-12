namespace Application.Services.Client.Carts.Queries.GetUserCart
{
    public class CartProductDto
    {
        public int ProductInCartId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }
    }
}
