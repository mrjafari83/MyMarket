using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Common.Category.Queries.GetAllCategories;
using Application.Services.Common.Category.Queries.GetChildrenOfCategory;
using Application.Services.Common.Category.Queries.GetCategoryById;

namespace Application.Interfaces.FacadPatterns.Common
{
    public interface ICommonCategorisFacad
    {
        IGetAllCategoriesService GetAllProductCategories { get; }
        IGetAllCategoriesService GetAllBlogCategories { get; }
        IGetChildrenOfCategoryService GetChildrenOfProductCategory { get; }
        IGetChildrenOfCategoryService GetChildrenOfBlogCategory { get; }
        IGetCategoryByIdService GetProductCategoryById { get; }
        IGetCategoryByIdService GetBlogCategoryById { get; }
    }
}
