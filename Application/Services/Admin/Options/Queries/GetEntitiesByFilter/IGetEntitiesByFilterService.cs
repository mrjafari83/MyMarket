using Application.Interfaces.Context;
using Application.Services.Admin.Options.Queries.GetEntitiesByFilter.Dtos;
using Common.Dto;
using Common.Enums;
using Common.Utilities;
using Common.ViewModels;
using Common.ViewModels.SearchViewModels;
using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Common.Category.Queries.GetCategoriesBySearch;
using Common.ViewModels.ExcelViewModels;

namespace Application.Services.Admin.Options.Queries.GetEntitiesByFilter
{
    public interface IGetEntitiesByFilterService
    {
        ResultDto<IEnumerable<object>> Execute(int filterId);
        IQueryable<Product> GetProductsByFilter(ProducsSearchViewModel filters);
    }

    public class GetEntitiesByFilterService : IGetEntitiesByFilterService
    {
        private readonly IDataBaseContext db;
        private readonly ILogger<GetEntitiesByFilterService> _logger;
        public GetEntitiesByFilterService(IDataBaseContext context, ILogger<GetEntitiesByFilterService> logger)
        {
            db = context;
            _logger = logger;
        }

        public ResultDto<IEnumerable<object>> Execute(int filterId)
        {
            try
            {
                var filter = db.SearchFilter.Find(filterId);
                IEnumerable<object> result = filter.SearchType switch
                {
                    //Products
                    Domain.Entities.Option.SearchItemType.Product => GetProductsByFilter(JsonConvertor<ProducsSearchViewModel>.LoadFromJsonString(filter.FilterJson))
                    .Select(p => new GetAllProductDetailsDto
                    {
                        Name = p.Name,
                        Brand = p.Brand,
                        CategoryName = p.Category.Name,
                        VisitNumber = p.Visits.Count(),
                        SellsCount = p.ProductInCarts.Where(p => !p.IsShow).Count()
                    }).AsNoTracking().ToList(),

                    //Blog Category
                    Domain.Entities.Option.SearchItemType.BlogCategory => GetBlogCategoryBySearch.GetCategories(db,JsonConvertor<BlogCategoryViewModel>.LoadFromJsonString(filter.FilterJson))
                    .Select(c=> new ExcelCategoryViewModel
                    {
                        Name=c.Name,
                        ParentName = c.Parent.Name ?? "ندارد",
                        ChildrenCount = c.Children.Count(),
                    }),

                    //Product Category
                    Domain.Entities.Option.SearchItemType.ProductCategory => GetProductCategoryBySearch.GetCategories(db,JsonConvertor<ProductCategoryViewModel>.LoadFromJsonString(filter.FilterJson))
                    .Select(c => new ExcelCategoryViewModel
                    {
                        Name = c.Name,
                        ParentName = c.Parent.Name ?? "ندارد",
                        ChildrenCount = c.Children.Count(),
                    }),
                };

                return new ResultDto<IEnumerable<object>>
                {
                    Data = result,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResultDto<IEnumerable<object>>
                {
                    Data = new List<object>(),
                    IsSuccess = false,
                    Message = "خطایی رخ داده است."
                };
            }
        }

        public IQueryable<Product> GetProductsByFilter(ProducsSearchViewModel filters)
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Visits).Include(p=> p.Inventories).Include(p=> p.ProductInCarts).AsQueryable();

            if (!string.IsNullOrEmpty(filters.SearchKey))
                switch (filters.SearchBy)
                {
                    case Enums.PageFilterCategory.Name:
                        {
                            products = products.Where(p => p.Name.Contains(filters.SearchKey));
                            break;
                        }
                    case Enums.PageFilterCategory.Brand:
                        {
                            products = products.Where(p => p.Brand.Contains(filters.SearchKey));
                            break;
                        }
                    case Enums.PageFilterCategory.CategoryName:
                        {
                            products = products.Where(p => p.Category.Name.Contains(filters.SearchKey));
                            break;
                        }
                }

            switch (filters.OrderBy)
            {
                case Enums.PagesFilter.LessViewed:
                    {
                        products = products.OrderBy(p => p.Visits.Count());
                        break;
                    }
                case Enums.PagesFilter.MostViewed:
                    {
                        products = products.OrderByDescending(p => p.Visits.Count());
                        break;
                    }
                case Enums.PagesFilter.Newest:
                    {
                        products = products.OrderByDescending(p => p.CreateDate);
                        break;
                    }
                case Enums.PagesFilter.Oldest:
                    {
                        products = products.OrderBy(p => p.CreateDate);
                        break;
                    }
                case Enums.PagesFilter.MostSelled:
                    {
                        products = products.OrderByDescending(p => p.ProductInCarts.Where(p => !p.IsShow)
                        .Sum(c => c.Count * c.ProductInventoryAndPrice.Price));
                        break;
                    }
                case Enums.PagesFilter.LessSelled:
                    {
                        products = products.OrderBy(p => p.ProductInCarts.Where(p => !p.IsShow)
                        .Sum(c => c.Count * c.ProductInventoryAndPrice.Price));
                        break;
                    }
            }

            if (filters.StartPrice != 0)
                products = products.Where(p => p.Inventories.Where(c => c.Price > filters.StartPrice).Count() != 0);

            if (filters.EndPrice != 0)
                products = products.Where(p => p.Inventories.Where(c => c.Price < filters.EndPrice).Count() != 0);

            return products;
        }
    }
}
