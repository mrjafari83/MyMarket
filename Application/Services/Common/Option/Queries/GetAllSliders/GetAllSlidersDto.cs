namespace Application.Services.Common.Option.Queries.GetAllSliders
{
    public class GetAllSlidersDto
    {
        public int SliderId { get; set; }
        public int ProductId { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int ProductInventory { get; set; }
    }
}
