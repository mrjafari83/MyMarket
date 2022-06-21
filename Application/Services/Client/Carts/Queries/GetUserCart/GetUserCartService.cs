using System.Linq;
using Common.Dto;
using Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;

namespace Application.Services.Client.Carts.Queries.GetUserCart
{
    public class GetUserCartService : IGetUserCartService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public GetUserCartService(IDataBaseContext context,IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }
        public ResultDto<GetUserCartDto> Execute(string userName)
        {
            var userCart = db.Carts.Where(c => c.UserName == userName).Select(c => new GetUserCartDto
            {
                CartId = c.Id,
                UserName = c.UserName,
            }).FirstOrDefault();

            userCart.Products = _mapper.Map<List<CartProductDto>>(db.ProductsInCart.Include(p => p.Product).ThenInclude(p=> p.Images)
                .Include(p=> p.ProductInventoryAndPrice)
                .Where(c => c.Cart.Id == userCart.CartId && c.IsShow));

            return new ResultDto<GetUserCartDto>
            {
                Data = userCart,
                IsSuccess = true
            };
        }
    }
}
