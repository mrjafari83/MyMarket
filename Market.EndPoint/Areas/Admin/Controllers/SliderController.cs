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
    [Authorize(Roles = "Admin,Owner")]
    public class SliderController : Controller
    {
        private ICommonOptionFacad _optionFacad;
        private ISliderFacad _sliderFacad;
        private IProductFacad _productFacad;
        private readonly IHostingEnvironment _environment;
        public SliderController(ICommonOptionFacad commonOptionFacad, ISliderFacad sliderFacad
            , IProductFacad productFacad, IHostingEnvironment environment)
        {
            _optionFacad = commonOptionFacad;
            _sliderFacad = sliderFacad;
            _productFacad = productFacad;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var slider = await _optionFacad.GetAllSlider.Execute();
            return View(slider.Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string url, IFormFile image)
        {
            if (image != null && url != null)
            {
                string imageSrc = await FileUploader.Upload(image, _environment, "Slider/");
                await _sliderFacad.CreateSlider.Execute(url, imageSrc);
            }
            return Redirect("/Admin/Slider");
        }

        [HttpGet]
        public IActionResult Replace(int sliderId)
        {
            ViewBag.SliderId = sliderId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Replace(int sliderId, string url, IFormFile image)
        {
            if (image != null && url != null && sliderId != 0)
            {
                string imageSrc = await FileUploader.Upload(image, _environment, "Slider/");
                await _sliderFacad.ReplaceSlider.Execute(sliderId, url, imageSrc);
            }
            return Redirect("/Admin/Slider");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _sliderFacad.DeleteSlider.Execute(id);
            return Redirect("/Admin/Slider");
        }
    }
}
