using Application.Interfaces.Context;
using AutoMapper;
using Common.Dto;
using Common.ViewModels;
using Domain.Entities.Cart;

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

        public ResultDto<int> Execute(CartPayingViewModel model)
        {
            var cartPaying = _mapper.Map<CartPayingInfo>(model);
            db.CartPayings.Add(cartPaying);
            db.SaveChanges();

            return new ResultDto<int>
            {
                Data = cartPaying.Id,
                IsSuccess = true,
            };
        }
    }
}
