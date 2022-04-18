using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;

namespace Market.EndPoint.ViewComponents.Admin
{
    public class CartPayingsInIndex : ViewComponent
    {
        private readonly ICartPayingFacad _cartPayingFacad;
        public CartPayingsInIndex(ICartPayingFacad cartPayingFacad)
        {
            _cartPayingFacad = cartPayingFacad;
        }

        public IViewComponentResult Invoke()
        {
            return View("CartPayingsInIndex" , _cartPayingFacad.GetAllCartPayings.Execute().Data);
        }
    }
}
