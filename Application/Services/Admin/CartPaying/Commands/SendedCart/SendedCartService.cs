using Application.Interfaces.Context;
using Common.Dto;

namespace Application.Services.Admin.CartPaying.Commands.SendedCart
{
    public class SendedCartService : ISendedCartService
    {
        private readonly IDataBaseContext db;
        public SendedCartService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(int cartPayingId)
        {
            var cartPaying = db.CartPayings.Find(cartPayingId);
            cartPaying.Sended = true;
            db.CartPayings.Update(cartPaying);
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
