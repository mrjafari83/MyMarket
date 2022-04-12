using System.Collections.Generic;

namespace Application.Services.Common.BlogPage.Queries.GetAllBlogPages
{
    public class GetAllBlogPagesResult
    {
        public int TotalRows { get; set; }
        public List<GetAllBlogPagesDto> BlogPages { get; set; }
    }
}
