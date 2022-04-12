using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Market.EndPoint.ViewComponents.Admin
{
    public class SizesInSelectList : ViewComponent
    {
        private readonly IProductSizeFacad _productSizeFacad;
        public SizesInSelectList(IProductSizeFacad productSizeFacad)
        {
            _productSizeFacad = productSizeFacad;
        }

        public IViewComponentResult Invoke()
        {
            return View("SizesInSelectList", _productSizeFacad.GetAllSizes.Execute().Data);
        }
    }
}
