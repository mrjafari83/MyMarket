using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Client.Carts.Commands.DeleteProductFromCart
{
    public interface IDeleteProductFromCartService
    {
        Task<ResultDto> Execute(int productInCartId, int cartId);
    }
}
