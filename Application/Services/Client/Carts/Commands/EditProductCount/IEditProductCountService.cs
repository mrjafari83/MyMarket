using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;

namespace Application.Services.Client.Carts.Commands.EditProductCount
{
    public interface IEditProductCountService
    {
        Task<ResultDto> Execute(int productInCartId, int count);
    }
}
