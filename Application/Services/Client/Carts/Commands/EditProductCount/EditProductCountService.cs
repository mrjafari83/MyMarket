using Application.Interfaces.Context;
using Common.Dto;

namespace Application.Services.Client.Carts.Commands.EditProductCount
{
    public class EditProductCountService : IEditProductCountService
    {
        private readonly IDataBaseContext db;
        public EditProductCountService(IDataBaseContext context)
        {
            this.db = context;
        }
        public ResultDto Execute(int productInCartId, int count)
        {
            var product = db.ProductsInCart.Find(productInCartId);
            product.Count = count;
            db.ProductsInCart.Update(product);
            db.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
