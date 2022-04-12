using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.Products.Queries.GetAllProducts
{
    public interface IGetAllProductsService
    {
        ResultDto<ResultGetAllProductsDto> Execute(int pageNumber , int pageSize);
    }
}
