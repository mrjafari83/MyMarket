using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Common;
using Microsoft.AspNetCore.Mvc;

namespace Market.EndPoint.ViewComponents
{
    public class ProductsInCartPaying : ViewComponent
    {
        private readonly ICommonCartFacad _commonCartFacad;
        public ProductsInCartPaying(ICommonCartFacad commonCartFacad)
        {
            _commonCartFacad = commonCartFacad;
        }

        public IViewComponentResult Invoke(int id)
        {
            return View("GetCartPayingProducts" , _commonCartFacad.GetCartPayingById.Execute(id).Result.Data.Products);
        }
    }
}
