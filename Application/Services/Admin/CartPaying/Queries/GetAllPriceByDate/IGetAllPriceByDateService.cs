using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Admin.CartPaying.Queries.GetAllPriceByDate
{
    public interface IGetAllPriceByDateService
    {
        ResultDto<int> Execute(int daysAgo);
    }

    public class GetAllPriceByDateService : IGetAllPriceByDateService
    {
        private readonly IDataBaseContext db;
        public GetAllPriceByDateService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<int> Execute(int daysAgo)
        {
            int price = 0;
            var date = DateTime.Now.AddDays(daysAgo);
            var products = db.ProductsInCart.Include(p=> p.ProductInventoryAndPrice).Include(p => p.CartPayingInfo).Include(p => p.Product)
                .Where(p => p.CartPayingInfo.PayDate.Day == date.Day).ToList();

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
