using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities.Products.Relations;
using Domain.Entities.Common;

namespace Domain.Entities.Products
{
    public class ProductFeature : BaseEntity
    {
        public string Display { get; set; }
        public string FeatureValue { get; set; }

        public virtual Product Product { get; set; }
    }
}
