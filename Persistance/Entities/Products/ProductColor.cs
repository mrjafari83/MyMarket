using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistance.Entities.Common;
using Persistance.Entities.Products.Relations;

namespace Persistance.Entities.Products
{
    public class ProductColor : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<ColorInProduct> Products { get; set; } 
    }
}
