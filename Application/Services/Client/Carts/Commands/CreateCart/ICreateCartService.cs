using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Client.Carts.Commands.CreateCart
{
    public interface ICreateCartService
    {
        ResultDto Execute(string userName , out int cartId);
    }
}
