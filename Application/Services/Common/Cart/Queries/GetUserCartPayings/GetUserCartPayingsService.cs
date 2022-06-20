using System.Collections.Generic;
using System.Linq;
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

        public ResultDto<List<GetUserCartPayingsDto>> Execute(string userName)
        {
            var cartPayings = db.CartPayings.Include(c => c.Cart).Include(c => c.Products).ThenInclude(c => c.Product)
                .Where(c => c.Cart.UserName == userName).Select(c => new GetUserCartPayingsDto
                {
                    Id = c.Id,
                    FullName = $"{c.Name} {c.Family}",
                    ProductsCount = c.Products.Count(),
                }).ToList();

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
