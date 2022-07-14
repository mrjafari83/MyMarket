using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Persistance.Context;
using AutoMapper;
using Application.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Admin.CartPaying.Queries.GetProductsOfCartPaying
{
    public class GetProductsOfCartPayingService : IGetProductsOfCartPayingService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public GetProductsOfCartPayingService(IDataBaseContext context , IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public async Task<ResultDto<List<ProductInCartPayingDto>>> Execute(int cartPayingId)
        {
            var products = _mapper.ProjectTo<ProductInCartPayingDto>(db.ProductsInCart.Include(p => p.Product).ThenInclude(p=> p.Inventories)
                .Include(p => p.Product).ThenInclude(p => p.Images)
                .Where(p => p.CartPayingInfo.Id == cartPayingId));

            if (products == null)
                return new ResultDto<List<ProductInCartPayingDto>>
                {
                    Data = null,
                    IsSuccess = false
                };
            return new ResultDto<List<ProductInCartPayingDto>>
            {
                Data = await products.AsNoTracking().ToListAsync(),
                IsSuccess = true
            };
        }
    }
}
