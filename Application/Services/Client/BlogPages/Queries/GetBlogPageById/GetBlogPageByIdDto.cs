namespace Application.Services.Client.BlogPages.Queries.GetBlogPageById
{
    public class GetBlogPageByIdDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public string CreateDate { get; set; }
    }
}
