using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Common.Utilities;
using Microsoft.AspNetCore.Hosting;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private ICommonOptionFacad _optionFacad;
        private ISliderFacad _sliderFacad;
        private IProductFacad _productFacad;
        private readonly IHostingEnvironment _environment;
        public SliderController(ICommonOptionFacad commonOptionFacad, ISliderFacad sliderFacad
            ,IProductFacad productFacad , IHostingEnvironment environment)
        {
            _optionFacad = commonOptionFacad;
            _sliderFacad = sliderFacad;
            _productFacad = productFacad;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View(_optionFacad.GetAllSlider.Execute().Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string url , IFormFile image)
        {
            string imageSrc = FileUploader.Upload(image, _environment, "Slider/");

            _sliderFacad.CreateSlider.Execute(url , imageSrc);
            return Redirect("/Admin/Slider");
        }

        [HttpGet]
        public IActionResult Replace(int sliderId)
        {
            ViewBag.SliderId = sliderId;
            return View();
        }

        [HttpPost]
        public IActionResult Replace(int sliderId , string url , IFormFile image)
        {
            string imageSrc = FileUploader.Upload(image, _environment, "Slider/");

            _sliderFacad.ReplaceSlider.Execute(sliderId, url , imageSrc);
            return Redirect("/Admin/Slider");
        }

        public IActionResult Delete(int id)
        {
            _sliderFacad.DeleteSlider.Execute(id);
            return Redirect("/Admin/Slider");
        }
    }
}
