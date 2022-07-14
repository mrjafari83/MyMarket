using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Common;
using Application.Persistance.Context;
using Application.Services.Common.Category.Queries.GetAllCategories;
using Application.Services.Common.Category.Queries.GetChildrenOfCategory;
using Application.Services.Common.Category.Queries.GetCategoryById;

namespace Application.FacadPatterns.Common
{
    public class CommonCategorisFacad : ICommonCategorisFacad
    {
        private readonly IDataBaseContext db;
        public CommonCategorisFacad(IDataBaseContext context)
        {
            db = context;
        }

        private GetAllProductCategoriesService _getAllProductCategoriesService;
        public GetAllProductCategoriesService GetAllProductCategories
        {
            get
            {
                return _getAllProductCategoriesService == null
                    ? new GetAllProductCategoriesService(db, new GetChildrenOfProductCategoryService(db))
                    : _getAllProductCategoriesService;
            }
        }

        private GetAllBlogCategoriesService _getAllBlogCategoriesService;
        public GetAllBlogCategoriesService GetAllBlogCategories
        {
            get
            {
                return _getAllBlogCategoriesService == null
                    ? new GetAllBlogCategoriesService(db, new GetChildrenOfBlogPageCategoryService(db))
                    : _getAllBlogCategoriesService;
            }
        }

        private GetChildrenOfProductCategoryService _getChildrenOfProductCategoryService;
        public IGetChildrenOfCategoryService GetChildrenOfProductCategory
        {
            get
            {
                return _getChildrenOfProductCategoryService ?? new GetChildrenOfProductCategoryService(db);
            }
        }

        private GetChildrenOfBlogPageCategoryService _getChildrenOfBlogPageCategoryService;
        public IGetChildrenOfCategoryService GetChildrenOfBlogCategory
        {
            get
            {
                return _getChildrenOfBlogPageCategoryService ?? new GetChildrenOfBlogPageCategoryService(db);
            }
        }

        private GetProductCategoryByIdService _getProductCategoryById;
        public IGetCategoryByIdService GetProductCategoryById
        {
            get
            {
                return _getProductCategoryById ?? new GetProductCategoryByIdService(db);
            }
        }

        private GetBlogCategoryByIdService _getBlogCategoryById;
        public IGetCategoryByIdService GetBlogCategoryById
        {
            get
            {
                return _getBlogCategoryById ?? new GetBlogCategoryByIdService(db);
            }
        }
    }
}
