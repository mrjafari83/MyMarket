using System;
using Common.Dto;
using Common.Utilities;
using Application.Interfaces.Context;

namespace Application.Services.Client.Carts.Commands.DeleteProductFromCart
{
    public class DeleteProductFromCartService : IDeleteProductFromCartService
    {
        private readonly IDataBaseContext db;
        public DeleteProductFromCartService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(int productInCartId , int cartId)
        {
            var produtInCart = db.ProductsInCart.Find(productInCartId);
            produtInCart.IsShow = false;
            db.ProductsInCart.Update(produtInCart);
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
