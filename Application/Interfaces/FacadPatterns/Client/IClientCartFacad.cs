using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Client.Carts.Commands.AddProductToCart;
using Application.Services.Client.Carts.Commands.CreateCart;
using Application.Services.Client.Carts.Commands.DeleteCart;
using Application.Services.Client.Carts.Commands.DeleteProductFromCart;
using Application.Services.Client.Carts.Commands.EditProductCount;
using Application.Services.Client.Carts.Commands.AddCartPaying;
using Application.Services.Client.Carts.Queries.GetUserCart;

namespace Application.Interfaces.FacadPatterns.Client
{
    public interface IClientCartFacad
    {
        IGetUserCartService GetUserCart { get; }
        ICreateCartService CreateCart { get; }
        IAddProductToCartService AddProductToCart { get; }
        IEditProductCountService EditProductCount { get; }
        IDeleteCartService DeleteCart { get; }
        IDeleteProductFromCartService DeleteProductFromCart { get; }
        IAddCartPayingService AddCartPaying { get; }
    }
}
