using Application.Common.ViewModels;
using System.Collections.Generic;

namespace Application.Services.Admin.BlogPages.Commands.CreateBlogPage
{
    public class CreateBlogPageDto
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public List<KeywordViewModel> Keywords { get; set; }
    }
}
