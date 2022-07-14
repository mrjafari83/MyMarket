using Common.Dto;
using Persistance.Context;
using Persistance.Entities.Cart;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Client.Carts.Commands.AddProductToCart
{
    public class AddProductToCartService : IAddProductToCartService
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public AddProductToCartService(IDataBaseContext context , IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public async Task<ResultDto> Execute(AddProductToCartDto model)
         {
            var cart = await db.Carts.FindAsync(model.CartId);
            var product = _mapper.Map<ProductInCart>(model);
            product.ProductInventoryAndPrice = await db.ProductInventories.FirstOrDefaultAsync(p => p.ProductId == product.ProductId 
            && (p.ColorName == product.Color || p.ColorName == null) && (p.SizeName == product.Size || p.SizeName == null));
            await db.ProductsInCart.AddAsync(product);
            await db.SaveChangesAsync();

            cart.Products.Add(await db.ProductsInCart.FindAsync(product.Id));

            db.Carts.Update(cart);
            await db.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
