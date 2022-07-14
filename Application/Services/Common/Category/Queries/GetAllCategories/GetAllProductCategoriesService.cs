﻿using System.Collections.Generic;
using System.Linq;
using Common.Dto;
using Common.Enums;
using Persistance.Context;
using Application.Services.Common.Category.Queries.GetChildrenOfCategory;
using Common.ViewModels.SearchViewModels;
using Application.Services.Common.Category.Queries.GetCategoriesBySearch;

namespace Application.Services.Common.Category.Queries.GetAllCategories
{
    public class GetAllProductCategoriesService
    {
        private readonly IDataBaseContext db;
        private readonly GetChildrenOfProductCategoryService getChildren;
        public GetAllProductCategoriesService(IDataBaseContext context
            ,GetChildrenOfProductCategoryService childrenOfProductCategoryService)
        {
            db = context;
            getChildren = childrenOfProductCategoryService;
        }

        public ResultDto<List<GetAllCategoriesDto>> Execute(ProductCategoryViewModel searchModel, bool withChildren, Enums.CategoriesFilter filter,bool justParent = false, int id = 0)
        {
            var categories = GetProductCategoryBySearch.GetCategories(db,searchModel).Select(c => new GetAllCategoriesDto
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
