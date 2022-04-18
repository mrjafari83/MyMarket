using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CartController : Controller
    {
        private readonly ICartPayingFacad _cartPayingFacad;
        public CartController(ICartPayingFacad cartPayingFacad)
        {
            _cartPayingFacad = cartPayingFacad;
        }

        public IActionResult OKSend(int cartPayingId)
        {
            _cartPayingFacad.SendedCart.Execute(cartPayingId);

            return Redirect("/Admin");
        }
    }
}
