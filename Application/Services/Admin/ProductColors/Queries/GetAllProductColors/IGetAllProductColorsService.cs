using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.ProductColors.Queries.GetAllProductColors
{
    public interface IGetAllProductColorsService
    {
        ResultDto<List<GetAllProductColorsDto>> Execute();
    }
}
