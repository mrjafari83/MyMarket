using Common.Dto;
using Application.Interfaces.Context;
using Domain.Entities.Cart;

namespace Application.Services.Client.Carts.Commands.CreateCart
{
    public class CreateCartService : ICreateCartService
    {
        private readonly IDataBaseContext db;
        public CreateCartService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(string userName , out int cartId)
        {
            var entity = db.Carts.Add(new Cart { UserName = userName });
            cartId = entity.Entity.Id;
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
            };
        }
    }
}
