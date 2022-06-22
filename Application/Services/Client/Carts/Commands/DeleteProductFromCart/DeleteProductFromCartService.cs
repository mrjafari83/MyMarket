using System;
using Common.Dto;
using Common.Utilities;
using Application.Interfaces.Context;
using System.Threading.Tasks;

namespace Application.Services.Client.Carts.Commands.DeleteProductFromCart
{
    public class DeleteProductFromCartService : IDeleteProductFromCartService
    {
        private readonly IDataBaseContext db;
        public DeleteProductFromCartService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto> Execute(int productInCartId , int cartId)
        {
            var produtInCart = await db.ProductsInCart.FindAsync(productInCartId);
            produtInCart.IsShow = false;
            db.ProductsInCart.Update(produtInCart);
            await db.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
