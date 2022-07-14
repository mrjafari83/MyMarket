using System.Linq;
using System.Threading.Tasks;
using Application.Persistance.Context;
using Application.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Admin.CartPaying.Queries.GetAllNotSendedPrice
{
    public class GetAllNotSendedPriceService : IGetAllNotSendedPriceService
    {
        private readonly IDataBaseContext db;
        public GetAllNotSendedPriceService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto<int>> Execute()
        {
            int price = 0;
            var products = await db.ProductsInCart.Include(p=> p.ProductInventoryAndPrice).Include(p => p.CartPayingInfo).Include(p=> p.Product)
                .Where(p => !p.CartPayingInfo.Sended && p.CartPayingInfo.IsPayed).ToListAsync();

            foreach (var item in products)
            {
                price += item.Count * item.ProductInventoryAndPrice.Price;
            }

            return new ResultDto<int>
            {
                Data = price,
                IsSuccess = true
            };
        }
    }
}
