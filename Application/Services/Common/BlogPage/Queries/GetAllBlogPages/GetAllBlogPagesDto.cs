namespace Application.Services.Common.BlogPage.Queries.GetAllBlogPages
{
    public class GetAllBlogPagesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        public string CategoryName { get; set; }
        public string CreateDate { get; set; }
        public int VisitNumber { get; set; }
    }
}
