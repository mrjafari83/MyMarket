using Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Client.Products.Queries.GetPriceByColorAndSize
{
    public interface IGetPriceAndInventoryByColorAndSizeService
    {
        ResultDto<GetPriceAndInventoryByColorAndSizeDto> Execute(int productId,string colorName, string sizeName);
    }
}
