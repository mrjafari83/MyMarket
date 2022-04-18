using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.CartPaying.Commands.SendedCart
{
    public interface ISendedCartService
    {
        ResultDto Execute(int cartPayingId);
    }
}
