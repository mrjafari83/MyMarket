using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities.Common;
using Domain.Entities.Products.Relations;

namespace Domain.Entities.Products
{
    public class ProductColor : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<ColorInProduct> Products { get; set; }
    }
}
