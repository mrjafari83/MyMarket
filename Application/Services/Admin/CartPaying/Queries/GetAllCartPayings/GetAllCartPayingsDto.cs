namespace Application.Services.Admin.CartPaying.Queries.GetAllCartPayings
{
    public class GetAllCartPayingsDto
    {
        public int CartId { get; set; }
        public int CartPayingId { get; set; }
        public string  Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Sended { get; set; }
    }
}
