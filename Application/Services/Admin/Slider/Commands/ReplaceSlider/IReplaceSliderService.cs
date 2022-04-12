using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.Slider.Commands.ReplaceSlider
{
    public interface IReplaceSliderService
    {
        ResultDto Execute(int lastProductId, int newProdcutId);
    }
}
