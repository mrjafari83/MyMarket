using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Client.Carts.Commands.DeleteProductFromCart
{
    public interface IDeleteProductFromCartService
    {
        ResultDto Execute(int productInCartId);
    }
}
