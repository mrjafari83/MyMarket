using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Services.Admin.CartPaying.Commands.SendedCart;
using Application.Services.Admin.CartPaying.Queries.GetAllCartPayings;
using Application.Services.Admin.CartPaying.Queries.GetAllPaysPrice;
using Application.Services.Admin.CartPaying.Queries.GetAllNotSendedPrice;
using Application.Services.Admin.CartPaying.Queries.GetNotSendedCount;

namespace Application.FacadPatterns.Admin
{
    public class CartPayingsFacad : ICartPayingFacad
    {
        private readonly IDataBaseContext db;
        public CartPayingsFacad(IDataBaseContext context)
        {
            db = context;
        }

        private GetAllCartPayingsService getAllCartPayingsService;
        public IGetAllCartPayingsService GetAllCartPayings 
        {
            get
            {
                return getAllCartPayingsService ?? new GetAllCartPayingsService(db);
            } 
        }

        private SendedCartService sendedCartService;
        public ISendedCartService SendedCart
        {
            get
            {
                return sendedCartService ?? new SendedCartService(db);
            }
        }

        private GetAllPaysPriceService getAllPaysPriceService;
        public IGetAllPaysPriceService GetAllPaysPrice
        {
            get
            {
                return getAllPaysPriceService ?? new GetAllPaysPriceService(db);
            }
        }

        private GetAllNotSendedPriceService getAllNotSendedPrice;
        public IGetAllNotSendedPriceService GetAllNotSendedPrice
        {
            get
            {
                return getAllNotSendedPrice ?? new GetAllNotSendedPriceService(db);
            }
        }

        private GetNotSendedCountSevice getNotSendedCountSevice;
        public IGetNotSendedCountSevice GetNotSendedCount
        {
            get
            {
                return getNotSendedCountSevice ?? new GetNotSendedCountSevice(db);
            }
        }
    }
}
