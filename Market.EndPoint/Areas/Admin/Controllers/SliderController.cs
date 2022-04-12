using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Common;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private ICommonOptionFacad _optionFacad;
        private ISliderFacad _sliderFacad;
        private IProductFacad _productFacad;
        public SliderController(ICommonOptionFacad commonOptionFacad, ISliderFacad sliderFacad
            ,IProductFacad productFacad)
        {
            _optionFacad = commonOptionFacad;
            _sliderFacad = sliderFacad;
            _productFacad = productFacad;
        }

        public IActionResult Index()
        {
            return View(_optionFacad.GetAllSlider.Execute().Data);
        }

        public IActionResult Create(int currentPage = 1)
        {
            ViewBag.CurrentRow = currentPage;
            return View(_productFacad.GetAllProductsService.Execute(currentPage , 10).Data);
        }

        public IActionResult Creating(int productId)
        {
            _sliderFacad.CreateSlider.Execute(productId);
            return Redirect("/Admin/Slider");
        }

        public IActionResult Replace(int sliderId, int currentPage = 1)
        {
            ViewBag.SliderId = sliderId;
            ViewBag.CurrentRow = currentPage;
            return View(_productFacad.GetAllProductsService.Execute(currentPage, 10).Data);
        }

        public IActionResult Replacing(int sliderId , int productId)
        {
            _sliderFacad.ReplaceSlider.Execute(sliderId, productId);
            return Redirect("/Admin/Slider");
        }

        public IActionResult Delete(int id)
        {
            _sliderFacad.DeleteSlider.Execute(id);
            return Redirect("/Admin/Slider");
        }
    }
}
