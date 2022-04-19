using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Admin.CartPaying.Queries.GetAllPaysPrice
{
    public interface IGetAllPaysPriceService
    {
        ResultDto<int> Execute();
    }

    public class GetAllPaysPriceService : IGetAllPaysPriceService
    {

        private readonly IDataBaseContext db;
        public GetAllPaysPriceService(IDataBaseContext context)
        {
            db = context;
        }
        public ResultDto<int> Execute()
        {
            int total = 0;
            var products = db.ProductsInCart.Include(p=> p.CartPayingInfo).Include(p=> p.Product).Where(p=> p.CartPayingInfo.IsPayed).ToList();
            foreach(var item in products)
            {
                total += item.Count * item.Product.Price;
            }

            return new ResultDto<int>
            {
                Data = total,
                IsSuccess = true
            };
        }
    }
}
