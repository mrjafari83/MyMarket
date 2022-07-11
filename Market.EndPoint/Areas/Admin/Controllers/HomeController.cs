using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Common;
using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Common.ViewModels.SearchViewModels;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
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
        [Route("/Admin/Error")]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> NewestProduct()
        {
            var products = await _commonProductFacad.GetNewestProduct.Execute(1, 10);
            return Json(products.Data.Products);
        }

        [HttpGet]
        public async Task<IActionResult> MostViewedProduct()
        {
            var products = await _commonProductFacad.GetMostViewedProduct.Execute(1, 10);
            return Json(products.Data.Products);
        }

        [HttpGet]
        public IActionResult NewestBlogPage()
        {
            return Json(_commonBlogPageFacad.GetAllBlogPages.Execute(new BlogPageSearchViewModel
            {
                OrderBy = Enums.BlogPagesFilter.Newest
            }).Result.Data);
        }

        [HttpGet]
        public IActionResult MostViewedBlogPage()
        {
            return Json(_commonBlogPageFacad.GetAllBlogPages.Execute(new BlogPageSearchViewModel
            {
                OrderBy = Enums.BlogPagesFilter.Newest
            }).Result.Data);
        }
    }
}
