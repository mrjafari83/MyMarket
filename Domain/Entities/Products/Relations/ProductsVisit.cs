using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.User;
using Domain.Entities.Products;

namespace Domain.Entities.Products.Relations
{
    public class ProductsVisit
    {
        public int Id { get; set; }
        public virtual Browser Browser { get; set; }
        public virtual Product Product { get; set; }  
    }
}
