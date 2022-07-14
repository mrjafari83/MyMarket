using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Admin.ProductFeature.Queries.GetAllProductFeatures
{
    public interface IGetAllProductFeatureService
    {
        ResultDto<List<GetAllProductFeatureDto>> Execute();
    }
}
