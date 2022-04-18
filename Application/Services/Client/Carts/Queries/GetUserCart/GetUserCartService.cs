using System.Linq;
using Common.Dto;
using Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Client.Carts.Queries.GetUserCart
{
    public class GetUserCartService : IGetUserCartService
    {
        private readonly IDataBaseContext db;
        public GetUserCartService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<GetUserCartDto> Execute(string userName)
        {
            var userCart = db.Carts.Where(c => c.UserName == userName).Include(c => c.Products).ThenInclude(c => c.Product).ThenInclude(p => p.Images).Select(c => new GetUserCartDto
            {
                CartId = c.Id,
                UserName = c.UserName,
            }).FirstOrDefault();

            userCart.Products = db.ProductsInCart.Where(c => c.Cart.Id == userCart.CartId).Select(p=> new CartProductDto 
            {
                Id = p.Product.Id,
                Name = p.Product.Name,
                Price = p.Product.Price,
                Count = p.Count,
                Image = p.Product.Images.FirstOrDefault().Src,
                ProductInCartId = p.Id,
            }).ToList();

            return new ResultDto<GetUserCartDto>
            {
                Data = userCart,
                IsSuccess = true
            };
        }
    }
}
