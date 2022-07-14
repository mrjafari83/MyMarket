using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Services.Client.Carts.Commands.AddProductToCart
{
    public interface IAddProductToCartService
    {
        Task<ResultDto> Execute(AddProductToCartDto model);
    }
}
