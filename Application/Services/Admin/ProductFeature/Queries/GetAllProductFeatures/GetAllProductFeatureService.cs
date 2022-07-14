using System.Collections.Generic;
using System.Linq;
using Application.Persistance.Context;
using Application.Common.Dto;

namespace Application.Services.Admin.ProductFeature.Queries.GetAllProductFeatures
{
    public class GetAllProductFeatureService : IGetAllProductFeatureService
    {
        private readonly IDataBaseContext db;
        public GetAllProductFeatureService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<List<GetAllProductFeatureDto>> Execute()
        {
            var features = db.ProductFutures.Select(f => new GetAllProductFeatureDto
            {
                Id = f.Id,
                Name = f.Display,
                Value = f.FeatureValue
            }).ToList();

            if (features != null)
                return new ResultDto<List<GetAllProductFeatureDto>>
                {
                    Data = features,
                    IsSuccess = true
                };
            else
                return new ResultDto<List<GetAllProductFeatureDto>>
                {                    Data = null,
                    IsSuccess = false                };        }
    }
}
