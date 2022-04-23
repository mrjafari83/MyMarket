using System.Collections.Generic;
using Application.Services.Admin.CartPaying.Queries.GetProductsOfCartPaying;

namespace Application.Services.Admin.CartPaying.Queries.GetCartPayingById
{
    public class GetCartPayingByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string PhoneNymber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public bool Sended { get; set; }
        public List<ProductInCartPayingDto> Products { get; set; }
    }
}
