using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Entities.Common;
using Persistance.Entities.Products;

namespace Persistance.Entities.Cart
{
    public class Cart : BaseEntity
    {
        public string UserName { get; set; }
        public virtual ICollection<ProductInCart> Products { get; set; }
        public virtual ICollection<CartPayingInfo> CartPayings { get; set; }
    }
}
