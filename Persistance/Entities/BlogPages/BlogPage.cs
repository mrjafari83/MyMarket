using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistance.Entities.Common;
using Persistance.Entities.Categories;
using Persistance.Entities.Comments;
using System.Web.Mvc;

namespace Persistance.Entities.BlogPages
{
    public class BlogPage : BaseEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        [AllowHtml]
        public string Text { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public virtual Category<BlogPage> Category { get; set; }
        public virtual ICollection<Keyword<BlogPage>> Keywords { get; set; }
        public virtual ICollection<Comment<BlogPage>> Comments { get; set; }
        public virtual ICollection<BlogPagesVisit> Visits { get; set; }
    }
}
