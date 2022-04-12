using System;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Client.Carts.Queries.GetUserCart
{
    public interface IGetUserCartService
    {
        ResultDto<GetUserCartDto> Execute(string userName);
    }
}
