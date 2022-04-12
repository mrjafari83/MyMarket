using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities.Common;
using Domain.Entities.Categories;
using Domain.Entities.Products.Relations;

namespace Domain.Entities.Products
{
    public class ProductSize : BaseEntity
    {
        public string Value { get; set; }

        public virtual ICollection<SizeInProduct> Products { get; set; }
    }
}
