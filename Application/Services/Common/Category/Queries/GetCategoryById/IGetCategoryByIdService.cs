using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Common.Category.Queries.GetCategoryById
{
    public interface IGetCategoryByIdService
    {
        ResultDto<GetCategoryByIdDto> Execute(int id);
    }
}
