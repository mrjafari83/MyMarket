using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Admin.ProductSizes.Queries.GetAllProductSizes
{
    public interface IGetAllProductSizesService
    {
        ResultDto<List<GetAllProductSizesDto>> Execute();
    }
}
