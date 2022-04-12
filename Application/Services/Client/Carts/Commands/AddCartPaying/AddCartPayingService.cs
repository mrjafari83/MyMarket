using Application.Interfaces.Context;
using Common.Dto;
using Common.ViewModels;
using Domain.Entities.Cart;

namespace Application.Services.Client.Carts.Commands.AddCartPaying
{
    public class AddCartPayingService : IAddCartPayingService
    {
        private readonly IDataBaseContext db;
        public AddCartPayingService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto<int> Execute(CartPayingViewModel model)
        {
            var cartPaying = db.CartPayings.Add(new CartPayingInfo
            {
                Name = model.Name,
                Family = model.Family,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                PostalCode = model.PostalCode,
                Email = model.Email,
                Cart = db.Carts.Find(model.CartId),
            });

            db.SaveChanges();

            return new ResultDto<int>
            {
                Data = cartPaying.Entity.Id,
                IsSuccess = true,
            };
        }
    }
}
