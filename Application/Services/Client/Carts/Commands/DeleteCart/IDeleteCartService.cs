using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Client.Carts.Commands.DeleteCart
{
    public interface IDeleteCartService
    {
        Task<ResultDto> Execute(int cartId);
    }
}
