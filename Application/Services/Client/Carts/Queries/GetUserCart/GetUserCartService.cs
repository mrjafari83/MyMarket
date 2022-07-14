using System.Linq;
using Application.Common.Dto;
using Application.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ResultDto<GetUserCartDto>> Execute(string userName)
        {
            var userCart = await db.Carts.Where(c => c.UserName == userName).Select(c => new GetUserCartDto
            {
                CartId = c.Id,
                UserName = c.UserName,
            }).FirstOrDefaultAsync();

            userCart.Products = await _mapper.ProjectTo<CartProductDto>(db.ProductsInCart.Include(p => p.Product).ThenInclude(p => p.Images)
                .Include(p => p.ProductInventoryAndPrice)
                .Where(c => c.Cart.Id == userCart.CartId && c.IsShow)).ToListAsync();

            return new ResultDto<GetUserCartDto>
            {
                Data = userCart,
                IsSuccess = true
            };
        }
    }
}
