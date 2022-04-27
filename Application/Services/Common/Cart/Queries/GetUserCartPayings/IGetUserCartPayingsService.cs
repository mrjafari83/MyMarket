using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Common.Cart.Queries.GetUserCartPayings
{
    public interface IGetUserCartPayingsService
    {
        ResultDto<List<GetUserCartPayingsDto>> Execute(string userName);
    }
}
