using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Common;
using Domain.Entities.Products;

namespace Domain.Entities.Cart
{
    public class Cart : BaseEntity
    {
        public string UserName { get; set; }
        public virtual ICollection<ProductInCart> Products { get; set; }
        public virtual ICollection<CartPayingInfo> CartPayings { get; set; }
    }
}
