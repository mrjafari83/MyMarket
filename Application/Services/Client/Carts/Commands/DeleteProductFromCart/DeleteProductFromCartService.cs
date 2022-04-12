using System;
using Common.Dto;
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

        public ResultDto Execute(int productInCartId)
        {
            var produtInCart = db.ProductsInCart.Find(productInCartId);
            produtInCart.IsRemoved = true;
            produtInCart.RemoveTime = DateTime.Now;
            db.ProductsInCart.Update(produtInCart);
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
