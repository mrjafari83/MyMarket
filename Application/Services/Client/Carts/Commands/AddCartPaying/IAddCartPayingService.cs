using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;
using Application.Common.ViewModels;

namespace Application.Services.Client.Carts.Commands.AddCartPaying
{
    public interface IAddCartPayingService
    {
        Task<ResultDto<int>> Execute(CartPayingViewModel model);
    }
}
