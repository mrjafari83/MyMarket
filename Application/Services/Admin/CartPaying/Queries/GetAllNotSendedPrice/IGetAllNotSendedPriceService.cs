using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Admin.CartPaying.Queries.GetAllNotSendedPrice
{
    public interface IGetAllNotSendedPriceService
    {
        Task<ResultDto<int>> Execute();
    }
}
