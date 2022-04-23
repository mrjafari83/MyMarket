using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.CartPaying.Queries.GetAllCartPayings;
using Application.Services.Admin.CartPaying.Queries.GetAllPaysPrice;
using Application.Services.Admin.CartPaying.Queries.GetAllNotSendedPrice;
using Application.Services.Admin.CartPaying.Queries.GetNotSendedCount;
using Application.Services.Admin.CartPaying.Queries.GetAllPriceByDate;
using Application.Services.Admin.CartPaying.Queries.GetCartPayingById;
using Application.Services.Admin.CartPaying.Commands.SendedCart;

namespace Application.Interfaces.FacadPatterns.Admin
{
    public interface ICartPayingFacad
    {
        IGetAllCartPayingsService GetAllCartPayings { get; }
        ISendedCartService SendedCart { get; }
        IGetAllPaysPriceService GetAllPaysPrice { get; }
        IGetAllNotSendedPriceService GetAllNotSendedPrice { get; }
        IGetNotSendedCountSevice GetNotSendedCount { get; }
        IGetAllPriceByDateService GetAllPriceByDate { get; }
        IGetCartPayingByIdService GetCartPayingById { get; }
    }
}
