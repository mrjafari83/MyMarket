using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Admin.CartPaying.Queries.GetProductsOfCartPaying
{
    public interface IGetProductsOfCartPayingService
    {
        ResultDto<List<ProductInCartPayingDto>> Execute(int cartPayingId);
    }
}
