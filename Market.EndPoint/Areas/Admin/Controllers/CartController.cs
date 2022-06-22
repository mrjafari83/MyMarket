using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Common;
using Microsoft.AspNetCore.Authorization;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class CartController : Controller
    {
        private readonly ICartPayingFacad _cartPayingFacad;
        private readonly ICommonCartFacad _commonCartFacad;
        public CartController(ICartPayingFacad cartPayingFacad , ICommonCartFacad commonCartFacad)
        {
            _cartPayingFacad = cartPayingFacad;
            _commonCartFacad = commonCartFacad;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _cartPayingFacad.GetAllCartPayings.Execute());
        }

        public async Task<IActionResult> CartPayingInfo(int id)
        {
            return View(await _commonCartFacad.GetCartPayingById.Execute(id));
        }

        public IActionResult OKSend(int cartPayingId)
        {
            _cartPayingFacad.SendedCart.Execute(cartPayingId);

            return Redirect("/Admin");
        }

        public async Task<IActionResult> GetAllPaysPrice()
        {
            var data = await _cartPayingFacad.GetAllPaysPrice.Execute();
            return Json(data.Data);
        }

        public async Task<IActionResult> GetNotSendedPrice()
        {
            var data = await _cartPayingFacad.GetAllNotSendedPrice.Execute();
            return Json(data.Data);
        }

        public async Task<IActionResult> GetNotSendedCount()
        {
            var count = await _cartPayingFacad.GetNotSendedCount.Execute();
            return Json(count.Data);
        }
    }
}
