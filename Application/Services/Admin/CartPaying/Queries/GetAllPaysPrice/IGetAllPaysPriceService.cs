using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.CartPaying.Queries.GetAllPaysPrice
{
    public interface IGetAllPaysPriceService
    {
         Task<ResultDto<int>> Execute();
    }
}
