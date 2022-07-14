using Common.Dto;
using System.Linq;
using Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Services.Client.Products.Queries.GetPriceByColorAndSize
{
    public class GetPriceAndInventoryByColorAndSizeService : IGetPriceAndInventoryByColorAndSizeService
    {
        private readonly IDataBaseContext db;
        public GetPriceAndInventoryByColorAndSizeService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto<GetPriceAndInventoryByColorAndSizeDto>> Execute(int productId ,string colorName, string sizeName)
        {
            var item = await db.ProductInventories.FirstOrDefaultAsync(p => p.ProductId == productId
            && (p.ColorName == colorName || p.ColorName == null) && (p.SizeName == sizeName || p.SizeName == null));
            int price = item.Price;
            int inventory = item.Inventory;

            if (price == 0)
                return new ResultDto<GetPriceAndInventoryByColorAndSizeDto>
                {
                    Data = null,
                    IsSuccess = false
                };
            return new ResultDto<GetPriceAndInventoryByColorAndSizeDto>
            {
                Data = new GetPriceAndInventoryByColorAndSizeDto
                {
                    Price = price,
                    Inventory = inventory,
                },
                IsSuccess = true
            };
        }
    }
}
