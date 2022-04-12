using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Common;

namespace Market.EndPoint.ViewComponents
{
    public class NewestProducts : ViewComponent 
    {
        private readonly ICommonProductFacad _commonProductFacad;
        public NewestProducts(ICommonProductFacad commonProductFacad)
        {
            _commonProductFacad = commonProductFacad;
        }

        public IViewComponentResult Invoke()
        {
            return View("NewestProducts" , _commonProductFacad.GetNewestProduct.Execute(1,8).Data);
        }
    }
}
