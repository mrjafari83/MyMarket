using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.CartPaying.Queries.GetAllCartPayings;
using Application.Services.Admin.CartPaying.Commands.SendedCart;

namespace Application.Interfaces.FacadPatterns.Admin
{
    public interface ICartPayingFacad
    {
        IGetAllCartPayingsService GetAllCartPayings { get; }
        ISendedCartService SendedCart { get; }
    }
}
