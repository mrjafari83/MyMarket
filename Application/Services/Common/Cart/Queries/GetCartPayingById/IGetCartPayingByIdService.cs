using System;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Common.Cart.Queries.GetCartPayingById
{
    public interface IGetCartPayingByIdService
    {
        ResultDto<GetCartPayingByIdDto> Execute(int id);
    }
}
