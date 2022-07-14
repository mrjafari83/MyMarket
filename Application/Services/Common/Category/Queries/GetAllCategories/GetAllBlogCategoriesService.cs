using System.Collections.Generic;
using System.Linq;
using Application.Common.Dto;
using Application.Common.Enums;
using Application.Persistance.Context;
using Application.Services.Common.Category.Queries.GetChildrenOfCategory;
using Application.Services.Common.Category.Queries.GetCategoriesBySearch;
using Application.Common.ViewModels.SearchViewModels;

namespace Application.Services.Common.Category.Queries.GetAllCategories
{
    public class GetAllBlogCategoriesService
    {
        private readonly IDataBaseContext db;
        private readonly GetChildrenOfBlogPageCategoryService getChildren;
        public GetAllBlogCategoriesService(IDataBaseContext context,
            GetChildrenOfBlogPageCategoryService getChildrenOfBlogPageCategoryService)
        {
            db = context;
            getChildren = getChildrenOfBlogPageCategoryService;
        }

        public ResultDto<List<GetAllCategoriesDto>> Execute(BlogCategoryViewModel searchModel , bool withChildren, Enums.CategoriesFilter filter,bool justParent = false , int id = 0)
        {
            var categories = GetBlogCategoryBySearch.GetCategories(db,searchModel).Select(c => new GetAllCategoriesDto
            {
                Id = c.Id,
                Name = c.Name,
                IsParent = c.IsParent,
                ParentId = c.Parent.Id == null ? 0 : c.Parent.Id,
                Children = c.Children.Select(child => new GetAllCategoriesDto
                {
                    Id = child.Id,
                    Name = child.Name,
                    IsParent = child.IsParent,
                    ParentId = child.Parent.Id,
                    Children = null
                }).ToList()
            }).AsQueryable();


            if (!withChildren)
            {
                switch (filter)
                {
                    case Enums.CategoriesFilter.ForCategoriesList:
                        {
                            categories = categories.Where(c => c.Id != id && c.Name != "بدون دسته بندی").Select(c => new GetAllCategoriesDto
                            {
                                Id = c.Id,
                                Name = c.Name,
                                IsParent = c.IsParent,
                                ParentId = c.ParentId,
                                Children = null
                            });

                            break;
                        }
                    case Enums.CategoriesFilter.ForPagesList:
                        {
                            categories = categories.Select(c => new GetAllCategoriesDto
                            {
                                Id = c.Id,
                                Name = c.Name,
                                IsParent = c.IsParent,
                                ParentId = c.ParentId,
                                Children = null
                            });
                            break;
                        }
                }
            }

            if (justParent)
                categories = categories.Where(c => c.IsParent);

            if (categories != null)
                return new ResultDto<List<GetAllCategoriesDto>>
                {
                    Data = categories.ToList(),
                    IsSuccess = true
                };
            else
                return new ResultDto<List<GetAllCategoriesDto>>
                {
                    Data = null,
                    IsSuccess = false
                };
        }


    }
}
