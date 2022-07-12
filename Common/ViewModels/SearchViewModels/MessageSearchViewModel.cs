using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels.SearchViewModels
{
    public class MessageSearchViewModel
    {
        public string SearchKey { get; set; }
        public Enums.Enums.MesssagesFilter SearchBy { get; set; }
    }
}
