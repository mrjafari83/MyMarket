using Common.ViewModels;
using System.Collections.Generic;

namespace Application.Services.Admin.BlogPages.Queries.GetBlogPageById
{
    public class GetBlogPageByIdDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string CreateDate { get; set; }
        public int VisitNumber { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<KeywordViewModel> Keywords { get; set; }
    }
}
