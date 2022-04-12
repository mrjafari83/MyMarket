using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Client;
using Common.Utilities;
using Common.ViewModels;

namespace Market.EndPoint.Controllers
{
    public class CartController : Controller
    {
        private readonly IClientCartFacad _clientCartFacad;
        public CartController(IClientCartFacad clientCartFacad)
        {
            _clientCartFacad = clientCartFacad;
        }

        [Route("AddToCart")]
        [HttpPost]
        public IActionResult AddToCart(int productId, int count, string returnUrl = "", string color = "", string size = "")
        {
            int cartId = Int32.Parse(CookiesManager.GetCookieValue(HttpContext, "CartId"));
            _clientCartFacad.AddProductToCart.Execute(cartId, productId, count, color, size);

            return Redirect(returnUrl == "" ? "/" : returnUrl);
        }

        [Route("DeleteProductFromCart")]
        [HttpPost]
        public IActionResult DeleteProductFromCart(int productInCartId)
        {
            _clientCartFacad.DeleteProductFromCart.Execute(productInCartId);
            return Redirect("/");
        }

        [Route("CartReview")]
        [HttpGet]
        public IActionResult CartReview()
        {
            return View(_clientCartFacad.GetUserCart.Execute(User.Identity.Name).Data);
        }

        [Route("EditCount")]
        [HttpPost]
        public IActionResult EditCount(int count , int productInCartId)
        {
            _clientCartFacad.EditProductCount.Execute(productInCartId, count);

            return Redirect("/");
        }

        [Route("SetAddress")]
        [HttpGet]
        public IActionResult SetAddress()
        {
            return View();
        }
    }
}
