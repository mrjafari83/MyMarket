using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Products.Relations;
using Domain.Entities.BlogPages;

namespace Domain.Entities.User
{
    public class Browser
    {
        public int Id { get; set; }
        public string BrowserCode { get; set; }

        public virtual ICollection<ProductsVisit> ProductsVisits { get; set; }
        public virtual ICollection<BlogPagesVisit> BlogPagesVisits { get; set; }
    }
}
