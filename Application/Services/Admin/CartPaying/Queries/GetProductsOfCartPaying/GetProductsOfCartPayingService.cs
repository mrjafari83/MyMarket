using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Context;
using Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Admin.CartPaying.Queries.GetProductsOfCartPaying
{
    public class GetProductsOfCartPayingService : IGetProductsOfCartPayingService
    {
        private readonly IDataBaseContext db;
        public GetProductsOfCartPayingService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<List<ProductInCartPayingDto>> Execute(int cartPayingId)
        {
            var products = db.ProductsInCart.Include(p=> p.Product).Where(p => p.CartPayingInfo.Id == cartPayingId).Select(p => new ProductInCartPayingDto
            {
                Id = p.Product.Id,
                Brand = p.Product.Brand,
                Name = p.Product.Name,
                Price = p.Product.Price,
                Color = p.Color,
                Count = p.Count,
                Size = p.Size
            }).ToList();

            if (products == null)
                return new ResultDto<List<ProductInCartPayingDto>>
                {
                    Data = null,
                    IsSuccess = false
                };
            return new ResultDto<List<ProductInCartPayingDto>>
            {
                Data = products,
                IsSuccess = true
            };
        }
    }
}
