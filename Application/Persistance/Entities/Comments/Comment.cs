using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistance.Entities.Common;

namespace Application.Persistance.Entities.Comments
{
    public class Comment<Type> : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public string ImageSrc { get; set; }
        public DateTime CreateDate { get; set; }
        public int VisitingParent { get; set; }

        public virtual Comment<Type> Parent { get; set; }
        public virtual ICollection<Comment<Type>> Children { get; set; }

        public virtual Type Location { get; set; }    
    }
}
