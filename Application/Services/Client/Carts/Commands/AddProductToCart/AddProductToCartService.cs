using Common.Dto;
using Application.Interfaces.Context;
using Domain.Entities.Cart;
using System.Linq;

namespace Application.Services.Client.Carts.Commands.AddProductToCart
{
    public class AddProductToCartService : IAddProductToCartService
    {
        private readonly IDataBaseContext db;
        public AddProductToCartService(IDataBaseContext context)
        {
            db = context;
        }

        public ResultDto Execute(int cartId, int productId, int productCount , int productPrice , string productColor = "", string productSize = "")
        {
            var cart = db.Carts.Find(cartId);
            var product = db.Products.Find(productId);
            var addingProduct = db.ProductsInCart.Add(new ProductInCart()
            {
                Product = product,
                Color = productColor,
                Size = productSize,
                Count = productCount,
                Cart = cart,
                ProductInventoryAndPrice = db.ProductInventories.FirstOrDefault(p=> p.ProductId == productId
                && p.SizeName == productSize && p.ColorName == productColor && p.Price == productPrice)
            }).Entity;
            db.SaveChanges();

            cart.Products.Add(db.ProductsInCart.Find(addingProduct.Id));

            db.Carts.Update(cart);
            db.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
