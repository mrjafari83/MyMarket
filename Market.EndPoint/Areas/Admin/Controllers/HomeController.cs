using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Common;
using Common.Enums;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ICommonProductFacad _commonProductFacad;
        private readonly ICommonBlogPageFacad _commonBlogPageFacad;
        public HomeController(ICommonProductFacad commonProductFacad , ICommonBlogPageFacad commonBlogPageFacad)
        {
            _commonProductFacad = commonProductFacad;
            _commonBlogPageFacad = commonBlogPageFacad;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sidebar()
        {
            return PartialView();
        }

        [HttpGet]
        [Route("/Admin/NotFound")]
        public IActionResult NotFound()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewestProduct()
        {
            return Json(_commonProductFacad.GetNewestProduct.Execute(1 , 10).Data.Products);
        }

        [HttpGet]
        public IActionResult MostViewedProduct()
        {
            return Json(_commonProductFacad.GetMostViewedProduct.Execute(1 , 10).Data.Products);
        }

        [HttpGet]
        public IActionResult NewestBlogPage()
        {
            return Json(_commonBlogPageFacad.GetAllBlogPages.Execute(filter:Enums.PagesFilter.Newest).Data);
        }

        [HttpGet]
        public IActionResult MostViewedBlogPage()
        {
            return Json(_commonBlogPageFacad.GetAllBlogPages.Execute(filter: Enums.PagesFilter.MostViewed).Data);
        }
    }
}
