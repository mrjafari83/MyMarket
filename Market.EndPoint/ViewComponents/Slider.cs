using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Common;
using Microsoft.AspNetCore.Mvc;

namespace Market.EndPoint.ViewComponents
{
    public class Slider : ViewComponent
    {
        private readonly ICommonOptionFacad _optionFacad;
        public Slider(ICommonOptionFacad optionFacad)
        {
            _optionFacad = optionFacad;
        }

        public IViewComponentResult Invoke()
        {
            return View(viewName: "Slider" , _optionFacad.GetAllSlider.Execute().Result.Data);
        }
    }
}
