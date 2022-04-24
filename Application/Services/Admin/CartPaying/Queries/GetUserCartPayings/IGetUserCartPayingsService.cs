using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.CartPaying.Queries.GetUserCartPayings
{
    public interface IGetUserCartPayingsService
    {
        ResultDto<List<GetUserCartPayingsDto>> Execute(string userName);
    }
}
