using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Entities.User;
using Persistance.Entities.Products;

namespace Persistance.Entities.Products.Relations
{
    public class ProductsVisit
    {
        public int Id { get; set; }
        public virtual Browser Browser { get; set; }
        public virtual Product Product { get; set; }  
    }
}
