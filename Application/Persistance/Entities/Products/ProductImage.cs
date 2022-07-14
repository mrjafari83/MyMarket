using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistance.Entities.Products
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Src { get; set; } = "/Images/DefaultProduct.PNG";

        public virtual Product Product { get; set; }
    }
}
