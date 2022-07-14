using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Client;
using Application.Common.Utilities;

namespace Market.EndPoint.ViewComponents
{
    public class Cart : ViewComponent
    {
        private readonly IClientCartFacad _clientCartFacad;
        public Cart(IClientCartFacad clientCartFacad)
        {
            _clientCartFacad = clientCartFacad;
        }

        public IViewComponentResult Invoke(string userName)
        {
            var cart = _clientCartFacad.GetUserCart.Execute(userName).Result.Data;
            if (!CookiesManager.ContainCookie(HttpContext, "CartId"))
                CookiesManager.AddCookie(HttpContext, "CartId", cart.CartId.ToString());
            return View("Cart", cart);
        }
    }
}
