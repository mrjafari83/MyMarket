using System;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Client.Carts.Queries.GetUserCart
{
    public interface IGetUserCartService
    {
        Task<ResultDto<GetUserCartDto>> Execute(string userName);
    }
}
