using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistance.Context;
using Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Client.Carts.Commands.VerifyPaying
{
    public interface IVerifyPayingService
    {
         Task<ResultDto> Execute(int cartPayingId , int cartId);
    }

    public class VerifyPayingService : IVerifyPayingService
    {
        private readonly IDataBaseContext db;
        public VerifyPayingService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto> Execute(int cartPayingId , int cartId)
        {
            var cartPaying = await db.CartPayings.FindAsync(cartPayingId);
            cartPaying.IsPayed = true;

            var products = await db.ProductsInCart.Include(p=> p.Product).Include(p=> p.ProductInventoryAndPrice)
                .Where(p => p.Cart.Id == cartId && p.IsShow).ToListAsync();
            foreach (var item in products)
            {
                item.CartPayingInfo = cartPaying;
                item.ProductInventoryAndPrice.Inventory -= item.Count;
            }

            db.CartPayings.Update(cartPaying);
            await db.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
