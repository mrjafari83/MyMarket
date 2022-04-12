using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Common;
using Application.Services.Common.Product.Queries.GetProductsByFilter;
using Application.Services.Common.Product.Queries.GetProductById;
using Application.Services.Common.Product.Queries.GetProductsBySearch;

namespace Application.FacadPatterns.Common
{
    public class CommonProductFacad : ICommonProductFacad
    {
        private readonly IDataBaseContext db;
        public CommonProductFacad(IDataBaseContext context)
        {
            db = context;
        }

        private GetMostViewedProductService _getMostViewedProductService;
        public IGetProductsByFilterService GetMostViewedProduct 
        {
            get
            {
                return _getMostViewedProductService ?? new GetMostViewedProductService(db);
            }
        }

        private GetNewestProductService _getNewestProductService;
        public IGetProductsByFilterService GetNewestProduct
        {
            get
            {
                return _getNewestProductService ?? new GetNewestProductService(db);
            }
        }

        private GetProductByIdService _getProductByIdService;
        public IGetProductByIdService GetProductById
        {
            get
            {
                return _getProductByIdService ?? new GetProductByIdService(db);
            }
        }

        private GetProductsBySearchService _getProductsBySearchService;
        public IGetProductsBySearchService GetProductsBySearch
        {
            get
            {
                return _getProductsBySearchService ?? new GetProductsBySearchService(db);
            }
        }
    }
}