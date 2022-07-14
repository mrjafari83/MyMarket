using System;
using System.Threading.Tasks;
using Application.Persistance.Context;
using Application.Common.Dto;

namespace Application.Services.Client.Carts.Commands.DeleteCart
{
    public class DeleteCartService : IDeleteCartService
    {
        private readonly IDataBaseContext db;
        public DeleteCartService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto> Execute(int cartId)
        {
            var cart = await db.Carts.FindAsync(cartId);
            cart.IsRemoved = true;
            cart.RemoveTime = DateTime.Now;
            db.Carts.Update(cart);
            await db.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
