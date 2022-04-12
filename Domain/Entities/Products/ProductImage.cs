using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Products
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Src { get; set; }

        public virtual Product Product { get; set; }
    }
}
