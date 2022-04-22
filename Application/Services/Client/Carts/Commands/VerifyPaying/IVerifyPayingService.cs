using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Client.Carts.Commands.VerifyPaying
{
    public interface IVerifyPayingService
    {
        ResultDto Execute(int cartPayingId , int cartId);
    }

    public class VerifyPayingService : IVerifyPayingService
    {
        private readonly IDataBaseContext db;
        public VerifyPayingService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(int cartPayingId , int cartId)
        {
            var cartPaying = db.CartPayings.Find(cartPayingId);
            cartPaying.IsPayed = true;

            var products = db.ProductsInCart.Include(p=> p.Product).Where(p => p.Cart.Id == cartId).ToList();
            foreach (var item in products)
            {
                item.CartPayingInfo = cartPaying;
                item.Product.Inventory = item.Product.Inventory - item.Count;
            }

            db.CartPayings.Update(cartPaying);
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
