using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistance.Entities.Products;
using Application.Persistance.Entities.Common;

namespace Application.Persistance.Entities.Cart
{
    public class ProductInCart : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual CartPayingInfo CartPayingInfo { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int Count { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public bool IsShow { get; set; } = true;
        public ProductInventory ProductInventoryAndPrice { get; set; }
    }
}
