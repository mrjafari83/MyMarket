using System.Collections.Generic;

namespace Application.Services.Client.Carts.Queries.GetUserCart
{
    public class GetUserCartDto
    {
        public int CartId { get; set; }
        public string UserName { get; set; }
        public List<CartProductDto> Products { get; set; }
    }
}
