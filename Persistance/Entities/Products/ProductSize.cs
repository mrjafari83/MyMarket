using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistance.Entities.Common;
using Persistance.Entities.Categories;
using Persistance.Entities.Products.Relations;

namespace Persistance.Entities.Products
{
    public class ProductSize : BaseEntity
    {
        public string SizeValue { get; set; }

        public virtual ICollection<SizeInProduct> Products { get; set; }
    }
}
