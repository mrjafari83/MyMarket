using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public class Enums
    {
        public enum CategoryType
        {
            Product,
            BlogPage
        }

        public enum PagesFilter
        {
            Newest,
            MostViewed
        }

        public enum CategoriesFilter
        {
            Non,
            ForPagesList,
            ForCategoriesList,
            Menu
        }
    }
}
