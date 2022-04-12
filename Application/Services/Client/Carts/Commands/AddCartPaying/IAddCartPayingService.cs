using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Common.ViewModels;

namespace Application.Services.Client.Carts.Commands.AddCartPaying
{
    public interface IAddCartPayingService
    {
        ResultDto<int> Execute(CartPayingViewModel model);
    }
}
