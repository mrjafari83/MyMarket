using System.Collections.Generic;
using System.Linq;
using Application.Persistance.Context;
using Application.Common.Dto;

namespace Application.Services.Admin.ProductSizes.Queries.GetAllProductSizes
{
    public class GetAllProductSizesService : IGetAllProductSizesService
    {
        private readonly IDataBaseContext db;
        public GetAllProductSizesService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<List<GetAllProductSizesDto>> Execute()
        {
            var sizes = db.ProductSizes.Select(s => new GetAllProductSizesDto
            {
                Id = s.Id,
                Value = s.SizeValue,
            }).ToList();

            if (sizes != null)
                return new ResultDto<List<GetAllProductSizesDto>>
                {
                    Data = sizes,
                    IsSuccess = true
                };
            else
                return new ResultDto<List<GetAllProductSizesDto>>
                {
                    Data = null,
                    IsSuccess = false
                };
        }
    }
}
