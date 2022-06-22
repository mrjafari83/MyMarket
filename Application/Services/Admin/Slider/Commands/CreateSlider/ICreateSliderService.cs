using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.Slider.Commands.CreateSlider
{
    public interface ICreateSliderService
    {
        Task<ResultDto> Execute(string url , string imageSrc);
    }
}
