using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistance.Entities.Common;
using Application.Persistance.Entities.Products;

namespace Application.Persistance.Entities.Cart
{
    public class Cart : BaseEntity
    {
        public string UserName { get; set; }
        public virtual ICollection<ProductInCart> Products { get; set; }
        public virtual ICollection<CartPayingInfo> CartPayings { get; set; }
    }
}
