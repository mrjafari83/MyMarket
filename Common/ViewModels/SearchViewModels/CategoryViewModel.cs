using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels.SearchViewModels
{
    public class ProductCategoryViewModel
    {
        public string SearchKey { get; set; } = "";
        public int ParentId { get; set; } = 0;
    }

    public class BlogCategoryViewModel
    {
        public string SearchKey { get; set; } = "";
        public int ParentId { get; set; } = 0;
    }
}
