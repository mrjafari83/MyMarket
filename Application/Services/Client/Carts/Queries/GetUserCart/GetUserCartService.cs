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
            var userCart = db.Carts.Where(c => c.UserName == userName).Select(c => new GetUserCartDto
            {
                CartId = c.Id,
                UserName = c.UserName,
            }).FirstOrDefault();

            userCart.Products = db.ProductsInCart.Include(p => p.Product).Where(c => c.Cart.Id == userCart.CartId).Select(p => new CartProductDto
            {
                Id = p.Product.Id,
                Name = p.Product.Name,
                Count = p.Count,
                Image = p.Product.Images.FirstOrDefault().Src,
                ProductInCartId = p.Id,
                Price = p.ProductInventoryAndPrice.Price == null ? 0 : p.ProductInventoryAndPrice.Price,
                ProductInventory = p.ProductInventoryAndPrice.Inventory == null ? 0 : p.ProductInventoryAndPrice.Inventory
            }).ToList();

            return new ResultDto<GetUserCartDto>
            {
                Data = userCart,
                IsSuccess = true
            };
        }
    }
}
