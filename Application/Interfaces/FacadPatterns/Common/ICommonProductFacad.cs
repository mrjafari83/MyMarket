using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Common.Product.Queries.GetProductsByFilter;
using Application.Services.Common.Product.Queries.GetProductById;
using Application.Services.Common.Product.Queries.GetProductsBySearch;

namespace Application.Interfaces.FacadPatterns.Common
{
    public interface ICommonProductFacad
    {
        IGetProductsByFilterService GetMostViewedProduct { get; }
        IGetProductsByFilterService GetNewestProduct { get; }
        IGetProductByIdService GetProductById { get; }
        IGetProductsBySearchService GetProductsBySearch { get; }
    }
}
