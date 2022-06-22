namespace Application.Services.Client.Carts.Commands.AddProductToCart
{
    public class AddProductToCartDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Count{ get; set; }
        public int Price { get; set; }
        public string Color { get; set; } = "";
        public string Size { get; set; } = "";
    }
}
