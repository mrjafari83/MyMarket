using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;

namespace Market.EndPoint.ViewComponents.Admin
{
    public class ColorsInSelectList : ViewComponent
    {
        private readonly IProductColorFacad _productColorFacad;
        public ColorsInSelectList(IProductColorFacad productColorFacad)
        {
            _productColorFacad = productColorFacad;
        }

        public IViewComponentResult Invoke()
        {
            return View("ColorsInSelectList", _productColorFacad.GetAllColors.Execute().Data);
        }
    }
}
