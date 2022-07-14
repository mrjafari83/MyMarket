using Application.Persistance.Context;
using Application.Common.Dto;
using System.Threading.Tasks;

namespace Application.Services.Client.Carts.Commands.EditProductCount
{
    public class EditProductCountService : IEditProductCountService
    {
        private readonly IDataBaseContext db;
        public EditProductCountService(IDataBaseContext context)
        {
            this.db = context;
        }
        public async Task<ResultDto> Execute(int productInCartId, int count)
        {
            var product =await db.ProductsInCart.FindAsync(productInCartId);
            product.Count = count;
            db.ProductsInCart.Update(product);
            await db.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
