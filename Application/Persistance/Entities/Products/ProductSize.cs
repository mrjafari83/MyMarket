using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Persistance.Entities.Common;
using Application.Persistance.Entities.Categories;
using Application.Persistance.Entities.Products.Relations;

namespace Application.Persistance.Entities.Products
{
    public class ProductSize : BaseEntity
    {
        public string SizeValue { get; set; }

        public virtual ICollection<SizeInProduct> Products { get; set; }
    }
}
