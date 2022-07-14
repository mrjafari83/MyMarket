using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;
using Application.Common.Enums;

namespace Application.Services.Common.Product.Queries.GetProductsByFilter
{
    public interface IGetProductsByFilterService
    {
         Task<ResultDto<ResultGetProductByFilterDto>> Execute(int pageNumber, int pageSize , int categoryId = 0);
    }
}
