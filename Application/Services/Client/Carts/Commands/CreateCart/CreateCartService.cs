using Common.Dto;
using Application.Interfaces.Context;
using Domain.Entities.Cart;
using System.Threading.Tasks;

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
            db.SaveChanges();
            cartId = entity.Entity.Id;

            return new ResultDto
            {
                IsSuccess = true,
            };
        }
    }
}
