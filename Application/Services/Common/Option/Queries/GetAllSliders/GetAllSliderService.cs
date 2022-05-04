using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Context;
using Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Common.Option.Queries.GetAllSliders
{
    public class GetAllSliderService : IGetAllSliderService
    {
        private readonly IDataBaseContext db;
        public GetAllSliderService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<List<GetAllSlidersDto>> Execute()
        {
            var sliders = db.Sliders.Select(s => new GetAllSlidersDto
            {
                SliderId = s.Id,
                Url = s.Url,
                ImageSrc = s.ImageSrc
            }).ToList();

            return new ResultDto<List<GetAllSlidersDto>>
            {
                Data = sliders,
                IsSuccess = true
            };
        }
    }
}
