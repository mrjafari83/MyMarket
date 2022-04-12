using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public string ImageSrc { get; set; }
        public int PageId { get; set; }
        public int ParentId { get; set; }
        public int VisitingParent { get; set; }
    }
}
