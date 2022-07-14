using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Persistance.Context;
using Application.Common.Dto;
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

        public async Task<ResultDto<List<GetAllSlidersDto>>> Execute()
        {
            var sliders = await db.Sliders.Select(s => new GetAllSlidersDto
            {
                SliderId = s.Id,
                Url = s.Url,
                ImageSrc = s.ImageSrc
            }).ToListAsync();

            return new ResultDto<List<GetAllSlidersDto>>
            {
                Data = sliders,
                IsSuccess = true
            };
        }
    }
}
