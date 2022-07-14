using Persistance.Context;
using AutoMapper;
using Common.Dto;
using Common.ViewModels;
using Persistance.Entities.Cart;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Client.Carts.Commands.AddCartPaying
{
    public class AddCartPayingService : IAddCartPayingService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public AddCartPayingService(IDataBaseContext context , IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public async Task<ResultDto<int>> Execute(CartPayingViewModel model)
        {
            var cartPaying = _mapper.Map<CartPayingInfo>(model);
            var result = await db.CartPayings.AddAsync(cartPaying);
            await db.SaveChangesAsync();

            return new ResultDto<int>
            {
                Data = cartPaying.Id,
                IsSuccess = true,
            };
        }
    }
}
