namespace Application.Services.Admin.CartPaying.Queries.GetUserCartPayings
{
    public class GetUserCartPayingsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int ProductsCount { get; set; }
        public int ProductsPrice { get; set; }
    }
}
