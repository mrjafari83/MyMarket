using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Market.EndPoint.ViewComponents.Admin
{
    public class BestSellingProductsInIndex : ViewComponent
    {
        private readonly IProductFacad _productFacad;
        public BestSellingProductsInIndex(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        public IViewComponentResult Invoke()
        {
            return View("BestSellingProductsInIndex", _productFacad.GetBestSellingProducts.Execute(1, 4).Result.Data);
        }
    }
}
