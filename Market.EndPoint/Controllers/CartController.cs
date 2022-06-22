using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Client;
using Common.Utilities;
using Common.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Market.EndPoint.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IClientCartFacad _clientCartFacad;
        public CartController(IClientCartFacad clientCartFacad)
        {
            _clientCartFacad = clientCartFacad;
        }

        [Route("AddToCart")]
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int count, int price, string color = "", string size = "")
        {
            int cartId = Int32.Parse(CookiesManager.GetCookieValue(HttpContext, "CartId"));
            await _clientCartFacad.AddProductToCart.Execute(new Application.Services.Client.Carts.Commands.AddProductToCart.AddProductToCartDto
            {
                ProductId = productId,
                Count = count,
                Price = price,
                Color = color,
                Size = size,
                CartId = cartId,
            });

            return Json(true);
        }

        [Route("DeleteProductFromCart")]
        [HttpPost]
        public async Task<IActionResult> DeleteProductFromCart(int productInCartId)
        {
            await _clientCartFacad.DeleteProductFromCart.Execute(productInCartId, Int32.Parse(CookiesManager.GetCookieValue(HttpContext, "CartId")));
            return Redirect("/");
        }

        [Route("CartReview")]
        [HttpGet]
        public async Task<IActionResult> CartReview()
        {
            var cart = await _clientCartFacad.GetUserCart.Execute(User.Identity.Name);
            return View(cart.Data);
        }

        [Route("EditCount")]
        [HttpPost]
        public async Task<IActionResult> EditCount(int count, int productInCartId)
        {
            await _clientCartFacad.EditProductCount.Execute(productInCartId, count);

            return Redirect("/");
        }

        [Route("SetAddress")]
        [HttpGet]
        public IActionResult SetAddress()
        {
            return View();
        }

        [Route("SetAddress")]
        [HttpPost]
        public async Task<IActionResult> SetAddress(CartPayingViewModel model)
        {
            model.CartId = Int32.Parse(CookiesManager.GetCookieValue(HttpContext, "CartId"));
            var cartPayingId = await _clientCartFacad.AddCartPaying.Execute(model);
            CookiesManager.AddCookie(HttpContext, "cartPayingId", cartPayingId.Data.ToString());
            return Redirect("/Paying");
        }

        [Route("Paying")]
        [HttpGet]
        public IActionResult Pay()
        {
            return View();
        }

        [Route("Paying")]
        [HttpPost]
        public async  Task<IActionResult> Paying()
        {
            await _clientCartFacad.VerifyPaying.Execute(Int32.Parse(CookiesManager.GetCookieValue(HttpContext, "cartPayingId")), Int32.Parse(CookiesManager.GetCookieValue(HttpContext, "CartId")));

            return Redirect("/VerifyCart");
        }

        [Route("VerifyCart")]
        [HttpGet]
        public async Task<IActionResult> VerifyCart()
        {
            var cart = await _clientCartFacad.GetUserCart.Execute(User.Identity.Name);
            return View(cart.Data);
        }

        [Route("DeleteCartData")]
        [HttpGet]
        public async Task<IActionResult> DeleteCartData()
        {
            var products = await _clientCartFacad.GetUserCart.Execute(User.Identity.Name);
            foreach (var item in products.Data.Products)
            {
                await _clientCartFacad.DeleteProductFromCart.Execute(item.ProductInCartId, Int32.Parse(CookiesManager.GetCookieValue(HttpContext, "CartId")));
            }

            return Redirect("/");
        }
    }
}
