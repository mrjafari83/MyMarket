using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistance.Entities.User;

namespace Application.Persistance.Entities.BlogPages
{
    public class BlogPagesVisit
    {
        public int Id { get; set; }
        public virtual Browser Browser { get; set; }
        public virtual BlogPage BlogPage { get; set; }
    }
}
