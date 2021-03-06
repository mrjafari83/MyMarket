using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Admin.Slider.Commands.DeleteSlider
{
    public interface IDeleteSliderService
    {
        Task<ResultDto> Execute(int sliderId);
    }
}
