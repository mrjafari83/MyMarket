using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Context;
using Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Common.Cart.Queries.GetUserCartPayings
{
    public class GetUserCartPayingsService : IGetUserCartPayingsService
    {
        private readonly IDataBaseContext db;
        public GetUserCartPayingsService(IDataBaseContext context)
        {
            db = context;
        }

        public async Task<ResultDto<List<GetUserCartPayingsDto>>> Execute(string userName)
        {
            var cartPayings = await db.CartPayings.Include(c => c.Cart).Include(c => c.Products).ThenInclude(c => c.Product)
                .Where(c => c.Cart.UserName == userName).Select(c => new GetUserCartPayingsDto
                {
                    Id = c.Id,
                    FullName = $"{c.Name} {c.Family}",
                    ProductsCount = c.Products.Count(),
                }).ToListAsync();

            if (cartPayings == null)
                return new ResultDto<List<GetUserCartPayingsDto>>
                {
                    Data = null,
                    IsSuccess = false
                };
            return new ResultDto<List<GetUserCartPayingsDto>>
            {
                Data = cartPayings,
                IsSuccess = true
            };
        }
    }
}
