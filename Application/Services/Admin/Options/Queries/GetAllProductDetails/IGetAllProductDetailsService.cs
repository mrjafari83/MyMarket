using Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Admin.Options.Queries.GetAllProductDetails
{
    public interface IGetAllProductDetailsService
    {
        ResultDto<List<GetAllProductDetailsDto>> Execute(int id);
    }
}
