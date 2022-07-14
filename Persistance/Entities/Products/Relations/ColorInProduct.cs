using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Entities.Common;

namespace Persistance.Entities.Products.Relations
{
    public class ColorInProduct : BaseEntity
    {
        public virtual Product Product { get; set; }
        public virtual ProductColor Color { get; set; }
    }
}
