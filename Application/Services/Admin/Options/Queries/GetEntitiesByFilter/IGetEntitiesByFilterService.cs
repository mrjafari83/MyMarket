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
using Application.Services.Common.BlogPage.GetBlogPagesBySearch;
using Application.Services.Admin.Message.Queries.GetMessagesBySearch;
using Application.Services.Admin.User.Queries.GetUsersBySearch;

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
        private readonly SaveLogInFile _saveLogInFile;
        private readonly IGetUserBySearch _getUserBySearch;
        public GetEntitiesByFilterService(IDataBaseContext context, SaveLogInFile saveLogInFile, IGetUserBySearch getUserBySearch)
        {
            db = context;
            _saveLogInFile = saveLogInFile;
            _getUserBySearch = getUserBySearch;
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

                    Domain.Entities.Option.SearchItemType.BlogPages=> GetBlogPagesBySearch.GetBlogPages(db,JsonConvertor<BlogPageSearchViewModel>.LoadFromJsonString(filter.FilterJson))
                    .Include(b=> b.Category).Select(b=> new ExcelBlogPagesViewModel
                    {
                        Title = b.Title,
                        ShortDescription = b.ShortDescription,
                        CategoryName = b.Category.Name,
                        VisitNumber = b.Visits.Count(),
                        CreateDate = b.CreateDate.ToShamsi()
                    }),

                    Domain.Entities.Option.SearchItemType.Message=>GetMessagesBySearch.GetMessages(db,JsonConvertor<MessageSearchViewModel>.LoadFromJsonString(filter?.FilterJson))
                    .Select(m=> new ExcelMessageViewModel
                    {
                        Name =m.Name,
                        Email = m.Email,
                        Website = m.Website,
                        Text = m.Message
                    }),

                    Domain.Entities.Option.SearchItemType.User => _getUserBySearch.GetUSers(JsonConvertor<UserSearchVIewModel>.LoadFromJsonString(filter?.FilterJson))
                    .Select(u=> new ExcelUserViewModel
                    {
                        UserName = u.UserName ?? "ندارد",
                        Email = u.Email ?? "ندارد",
                        Name = u.Name ?? "ندارد",
                        Family = u.Family ?? "ندارد",
                        PhoneNumber = u.PhoneNumber ?? "ندارد",
                    })
                };

                return new ResultDto<IEnumerable<object>>
                {
                    Data = result,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                _saveLogInFile.Log(LogLevel.Error, ex.Message, "Get Entities By search in Application");
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
                case Enums.ProductsFilter.LessViewed:
                    {
                        products = products.OrderBy(p => p.Visits.Count());
                        break;
                    }
                case Enums.ProductsFilter.MostViewed:
                    {
                        products = products.OrderByDescending(p => p.Visits.Count());
                        break;
                    }
                case Enums.ProductsFilter.Newest:
                    {
                        products = products.OrderByDescending(p => p.CreateDate);
                        break;
                    }
                case Enums.ProductsFilter.Oldest:
                    {
                        products = products.OrderBy(p => p.CreateDate);
                        break;
                    }
                case Enums.ProductsFilter.MostSelled:
                    {
                        products = products.OrderByDescending(p => p.ProductInCarts.Where(p => !p.IsShow)
                        .Sum(c => c.Count * c.ProductInventoryAndPrice.Price));
                        break;
                    }
                case Enums.ProductsFilter.LessSelled:
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
