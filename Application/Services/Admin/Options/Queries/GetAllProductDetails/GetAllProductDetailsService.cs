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
using Common.Utilities;

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
            var filters = db.SearchFilter.FirstOrDefault(k=> k.Id == filterId);
            var filterXml = XmlConvertor<SearchViewModel>.LoadFromXMLString(filters.FilterXml);

            var products = _getProductsBySearch.GetProducts(new SearchViewModel
            {
                SearchKey = filterXml.SearchKey,
                StartPrice = filterXml.StartPrice,
                EndPrice = filterXml.EndPrice,
                SearchBy = filterXml.SearchBy,
                OrderBy = filterXml.OrderBy,
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
