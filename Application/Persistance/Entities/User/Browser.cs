using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistance.Entities.Products.Relations;
using Application.Persistance.Entities.BlogPages;

namespace Application.Persistance.Entities.User
{
    public class Browser
    {
        public int Id { get; set; }
        public string BrowserCode { get; set; }

        public virtual ICollection<ProductsVisit> ProductsVisits { get; set; }
        public virtual ICollection<BlogPagesVisit> BlogPagesVisits { get; set; }
    }
}
