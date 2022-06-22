using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Common;

namespace Market.EndPoint.ViewComponents
{
    public class MostViewedProducts : ViewComponent
    {
        private readonly ICommonProductFacad _commonProductFacad;
        public MostViewedProducts(ICommonProductFacad commonProductFacad)
        {
            _commonProductFacad = commonProductFacad;
        }

        public IViewComponentResult Invoke()
        { 
            return View("MostViewedProducts", _commonProductFacad.GetMostViewedProduct.Execute(1, 3).Result.Data);
        } 
    }
}
