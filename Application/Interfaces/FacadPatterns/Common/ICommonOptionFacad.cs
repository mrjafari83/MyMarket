using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Common.Option.Queries.GetAllSliders;
using Application.Services.Common.Option.Commands.CreateBrowser;

namespace Application.Interfaces.FacadPatterns.Common
{
    public interface ICommonOptionFacad
    {
        IGetAllSliderService GetAllSlider { get; }
        ICreateBrowserService CreateBrowser { get; }
    }
}
