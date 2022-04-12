using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Context;
using Common.Dto;

namespace Application.Services.Admin.ProductColors.Queries.GetAllProductColors
{
    public class GetAllProductColorsService : IGetAllProductColorsService
    {
        private readonly IDataBaseContext db;
        public GetAllProductColorsService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<List<GetAllProductColorsDto>> Execute()
        {
            var colors = db.ProductColors.Select(c => new GetAllProductColorsDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            if (colors != null)
                return new ResultDto<List<GetAllProductColorsDto>>
                {
                    Data = colors,
                    IsSuccess = true
                };
            else
                return new ResultDto<List<GetAllProductColorsDto>>
                {
                    Data = null,
                    IsSuccess = false
                };
        }
    }
}
