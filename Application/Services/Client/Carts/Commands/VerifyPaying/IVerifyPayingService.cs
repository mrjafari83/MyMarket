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

            //var products = db.ProductsInCart.Where(p => p.Cart.Id == cartId).Include(p=> p.Product).Include(p=> p.Cart).ToList();
            //foreach(var item in products)
            //{
            //    cartPaying.Products.Add(item);
            //}

            var products = db.ProductsInCart.Where(p => p.Cart.Id == cartId).ToList();
            foreach (var item in products)
            {
                item.CartPayingInfo = cartPaying;
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
