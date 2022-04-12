using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities.Common;

namespace Domain.Entities.Categories
{
    public class Category<Type> : BaseEntity
    {
        public string Name { get; set; }
        public bool IsParent { get; set; }

        public virtual Category<Type> Parent { get; set; }
        public virtual ICollection<Category<Type>> Children { get; set; }

        public virtual ICollection<Type> Location { get; set; }
    }
}
