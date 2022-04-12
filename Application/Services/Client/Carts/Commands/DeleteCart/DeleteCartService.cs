using System;
using Application.Interfaces.Context;
using Common.Dto;

namespace Application.Services.Client.Carts.Commands.DeleteCart
{
    public class DeleteCartService : IDeleteCartService
    {
        private readonly IDataBaseContext db;
        public DeleteCartService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(int cartId)
        {
            var cart = db.Carts.Find(cartId);
            cart.IsRemoved = true;
            cart.RemoveTime = DateTime.Now;
            db.Carts.Update(cart);
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
