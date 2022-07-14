using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Admin.Slider.Commands.ReplaceSlider
{
    public interface IReplaceSliderService
    {
        Task<ResultDto> Execute(int lastProductId, string url , string imageSrc);
    }
}
