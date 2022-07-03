using Application.Interfaces.Context;
using Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using Common.Enums;

namespace Application.Services.Admin.Common.Queries.GetProductsBySearch
{
    public class GetProductsBySearch
    {
        private readonly IDataBaseContext db;
        public GetProductsBySearch(IDataBaseContext context)
        {
            db = context;
        }

        public IQueryable<Product> GetProducts(SearchViewModel model)
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Visits).AsQueryable();

            if (!string.IsNullOrEmpty(model.SearchKey))
                switch (model.SearchBy)
                {
                    case Enums.PageFilterCategory.Name:
                        {
                            products = products.Where(p => p.Name.Contains(model.SearchKey));
                            break;
                        }
                    case Enums.PageFilterCategory.Brand:
                        {
                            products = products.Where(p => p.Brand.Contains(model.SearchKey));
                            break;
                        }
                    case Enums.PageFilterCategory.CategoryName:
                        {
                            products = products.Where(p => p.Category.Name.Contains(model.SearchKey));
                            break;
                        }
                }

            switch (model.OrderBy)
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

            if (model.StartPrice != 0)
                products = products.Where(p => p.Inventories.Where(c => c.Price > model.StartPrice).Count() != 0);

            if (model.EndPrice != 0)
                products = products.Where(p => p.Inventories.Where(c => c.Price < model.EndPrice).Count() != 0);

            return products;
        }
    }
}
