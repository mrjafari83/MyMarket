using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Common.Enums;

namespace Application.Services.Common.Product.Queries.GetProductsByFilter
{
    public interface IGetProductsByFilterService
    {
        ResultDto<ResultGetProductByFilterDto> Execute(int pageNumber, int pageSize , int categoryId = 0);
    }
}
