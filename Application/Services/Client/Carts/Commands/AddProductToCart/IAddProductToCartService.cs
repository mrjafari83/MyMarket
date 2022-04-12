using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Client.Carts.Commands.AddProductToCart
{
    public interface IAddProductToCartService
    {
        ResultDto Execute(int cartId, int productId , int productCount, string productColor, string productSize);
    }
}
