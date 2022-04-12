using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Common.Option.Queries.GetAllSliders
{
    public interface IGetAllSliderService
    {
        ResultDto<List<GetAllSlidersDto>> Execute();
    }
}
