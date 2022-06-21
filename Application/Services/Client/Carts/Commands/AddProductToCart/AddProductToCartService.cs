using Common.Dto;
using Application.Interfaces.Context;
using Domain.Entities.Cart;
using System.Linq;
using AutoMapper;

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

        public ResultDto Execute(AddProductToCartDto model)
         {
            var cart = db.Carts.Find(model.CartId);
            var product = _mapper.Map<ProductInCart>(model);
            product.ProductInventoryAndPrice = db.ProductInventories.FirstOrDefault(p => p.ProductId == product.ProductId 
            && (p.ColorName == product.Color || p.ColorName == null) && (p.SizeName == product.Size || p.SizeName == null));
            db.ProductsInCart.Add(product);
            db.SaveChanges();

            cart.Products.Add(db.ProductsInCart.Find(product.Id));

            db.Carts.Update(cart);
            db.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }

    public class AddProductToCartDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Count{ get; set; }
        public int Price { get; set; }
        public string Color { get; set; } = "";
        public string Size { get; set; } = "";
    }
}
