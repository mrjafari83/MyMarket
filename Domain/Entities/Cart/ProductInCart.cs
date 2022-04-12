using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Products;
using Domain.Entities.Common;

namespace Domain.Entities.Cart
{
    public class ProductInCart : BaseEntity
    {
        public virtual Product Product { get; set; }
        public Cart Cart { get; set; }
        public int Count { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
}
