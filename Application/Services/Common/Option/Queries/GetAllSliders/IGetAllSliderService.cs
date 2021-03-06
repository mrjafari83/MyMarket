using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Common.Option.Queries.GetAllSliders
{
    public interface IGetAllSliderService
    {
        Task<ResultDto<List<GetAllSlidersDto>>> Execute();
    }
}
