using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Entities.Products.Relations;
using Persistance.Entities.BlogPages;

namespace Persistance.Entities.User
{
    public class Browser
    {
        public int Id { get; set; }
        public string BrowserCode { get; set; }

        public virtual ICollection<ProductsVisit> ProductsVisits { get; set; }
        public virtual ICollection<BlogPagesVisit> BlogPagesVisits { get; set; }
    }
}
