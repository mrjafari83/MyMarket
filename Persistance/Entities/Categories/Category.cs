using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistance.Entities.Common;

namespace Persistance.Entities.Categories
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
