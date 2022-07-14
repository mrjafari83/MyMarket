using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ViewModels.SearchViewModels
{
    public class BlogPageSearchViewModel
    {
        public string SearchKey { get; set; } = "";
        public int CategoryId { get; set; } = 0;
        public Enums.Enums.BlogPagesFilter OrderBy { get; set; } = Enums.Enums.BlogPagesFilter.Newest;
    }
}
