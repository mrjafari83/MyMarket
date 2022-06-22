using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Admin.CartPaying.Queries.GetAllPaysPrice
{
    public class GetAllPaysPriceService : IGetAllPaysPriceService
    {

        private readonly IDataBaseContext db;
        public GetAllPaysPriceService(IDataBaseContext context)
        {
            db = context;
        }
        public async  Task<ResultDto<int>> Execute()
        {
            int total = 0;
            var products = await db.ProductsInCart.Include(p=> p.ProductInventoryAndPrice).Include(p=> p.CartPayingInfo).Include(p=> p.Product)
                .Where(p=> p.CartPayingInfo.IsPayed).ToListAsync();
            foreach (var item in products)
            {
                total += item.Count * item.ProductInventoryAndPrice.Price;
            }

            return new ResultDto<int>
            {
                Data = total,
                IsSuccess = true
            };
        }
    }
}
