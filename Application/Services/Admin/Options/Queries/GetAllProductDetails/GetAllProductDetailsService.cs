using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Admin;
using Common.Dto;
using Common.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Admin.Common.Queries.GetProductsBySearch;
using Common.ViewModels;

namespace Application.Services.Admin.Options.Queries.GetAllProductDetails
{
    public class GetAllProductDetailsService : IGetAllProductDetailsService
    {
        private readonly IDataBaseContext db;
        private readonly GetProductsBySearch _getProductsBySearch;
        public GetAllProductDetailsService(IDataBaseContext context)
        {
            db = context;
            _getProductsBySearch = new GetProductsBySearch(context);
        }

        public ResultDto<List<GetAllProductDetailsDto>> Execute(int filterId)
        {
            var filters = db.ExcelKeys.FirstOrDefault(k=> k.Id == filterId);
            Enums.PagesFilter orderBy = filters.OrderBy switch
            {
                0 => Enums.PagesFilter.Newest,
                1 => Enums.PagesFilter.Oldest,
                2 => Enums.PagesFilter.MostViewed,
                3 => Enums.PagesFilter.MostSelled,
                4 => Enums.PagesFilter.LessViewed,
                5 => Enums.PagesFilter.LessSelled,
                _ => Enums.PagesFilter.Newest
            };

            Enums.PageFilterCategory searchBy = filters.SearchBy switch
            {
                0 => Enums.PageFilterCategory.Name,
                1 => Enums.PageFilterCategory.Brand,
                2 => Enums.PageFilterCategory.CategoryName,
                _ => Enums.PageFilterCategory.Name
            };

            var products = _getProductsBySearch.GetProducts(new SearchViewModel
            {
                SearchKey = filters.SearchKey,
                SearchBy = searchBy,
                OrderBy = orderBy,
                StartPrice = filters.StartPrice,
                EndPrice = filters.EndPrice,
            }).Include(p=> p.ProductInCarts).Select(p=> new GetAllProductDetailsDto
            {
                Name = p.Name,
                Brand = p.Brand,
                CategoryName = p.Category.Name,
                VisitNumber = p.Visits.Count(),
                SellsCount  =p.ProductInCarts.Where(p=> !p.IsShow).Count()
            }).AsNoTracking().ToList();

            return new ResultDto<List<GetAllProductDetailsDto>>
            {
                Data = products,
            IsSuccess = true
            };
        }
    }
}
