using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Common.Option.Queries.GetAllSliders;

namespace Application.Interfaces.FacadPatterns.Common
{
    public interface ICommonOptionFacad
    {
        IGetAllSliderService GetAllSlider { get; }
    }
}
