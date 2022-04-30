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
    public class CartController : Controller
    {
        private readonly ICartPayingFacad _cartPayingFacad;
        private readonly ICommonCartFacad _commonCartFacad;
        public CartController(ICartPayingFacad cartPayingFacad , ICommonCartFacad commonCartFacad)
        {
            _cartPayingFacad = cartPayingFacad;
            _commonCartFacad = commonCartFacad;
        }

        public IActionResult Index()
        {
            return View(_cartPayingFacad.GetAllCartPayings.Execute().Data);
        }

        public IActionResult CartPayingInfo(int id)
        {
            return View(_commonCartFacad.GetCartPayingById.Execute(id).Data);
        }

        public IActionResult OKSend(int cartPayingId)
        {
            _cartPayingFacad.SendedCart.Execute(cartPayingId);

            return Redirect("/Admin");
        }

        public IActionResult GetAllPaysPrice()
        {
            var data = _cartPayingFacad.GetAllPaysPrice.Execute().Data;
            return Json(data);
        }

        public IActionResult GetNotSendedPrice()
        {
            var data = _cartPayingFacad.GetAllNotSendedPrice.Execute().Data;
            return Json(data);
        }

        public IActionResult GetNotSendedCount()
        {
            return Json(_cartPayingFacad.GetNotSendedCount.Execute().Data);
        }
    }
}
