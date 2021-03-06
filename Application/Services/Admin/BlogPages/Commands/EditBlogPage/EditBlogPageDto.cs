using System.Collections.Generic;
using Application.Common.ViewModels;

namespace Application.Services.Admin.BlogPages.Commands.EditBlogPage
{
    public class EditBlogPageDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public List<KeywordViewModel> Keywords { get; set; }
    }
}
