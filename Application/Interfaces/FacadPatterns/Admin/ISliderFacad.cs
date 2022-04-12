using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.Slider.Commands.CreateSlider;
using Application.Services.Admin.Slider.Commands.ReplaceSlider;
using Application.Services.Admin.Slider.Commands.DeleteSlider;

namespace Application.Interfaces.FacadPatterns.Admin
{
    public interface ISliderFacad
    {
        ICreateSliderService CreateSlider { get; }
        IReplaceSliderService ReplaceSlider { get; }
        IDeleteSliderService DeleteSlider { get; }
    }
}
