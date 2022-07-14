using Persistance.Context;
using Persistance.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ViewModels.SearchViewModels;

namespace Application.Services.Common.Category.Queries.GetCategoriesBySearch
{
    public class GetBlogCategoryBySearch
    {
        public static IQueryable<Category<Persistance.Entities.BlogPages.BlogPage>> GetCategories(IDataBaseContext db , BlogCategoryViewModel searchModel)
        {
            var data = db.BlogPageCategories.AsQueryable();
            if(searchModel != null)
            {
                if(searchModel.SearchKey != null && searchModel.SearchKey != "")
                    data = data.Where(c=> c.Name.Contains(searchModel.SearchKey));

                if(searchModel.ParentId != 0)
                    data = data.Where(c=> c.Parent.Id == searchModel.ParentId);
            }

            return data;
        }
    }

    public class GetProductCategoryBySearch
    {
        public static IQueryable<Category<Persistance.Entities.Products.Product>> GetCategories(IDataBaseContext db, ProductCategoryViewModel searchModel)
        {
            var data = db.ProductCategories.AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.SearchKey != null && searchModel.SearchKey != "")
                    data = data.Where(c => c.Name.Contains(searchModel.SearchKey));

                if (searchModel.ParentId != 0)
                    data = data.Where(c => c.Parent.Id == searchModel.ParentId);
            }

            return data;
        }
    }
}
