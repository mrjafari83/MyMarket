using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Persistance.Context;
using Application.Interfaces.FacadPatterns.Client;
using Application.Services.Client.Carts.Commands.AddProductToCart;
using Application.Services.Client.Carts.Commands.CreateCart;
using Application.Services.Client.Carts.Commands.DeleteCart;
using Application.Services.Client.Carts.Commands.DeleteProductFromCart;
using Application.Services.Client.Carts.Commands.EditProductCount;
using Application.Services.Client.Carts.Queries.GetUserCart;
using Application.Services.Client.Carts.Commands.AddCartPaying;
using Application.Services.Client.Carts.Commands.VerifyPaying;
using AutoMapper;

namespace Application.FacadPatterns.Client
{
    public class ClientCartFacad : IClientCartFacad
    {
        private readonly IDataBaseContext db;
        private readonly IMapper _mapper;
        public ClientCartFacad(IDataBaseContext context , IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        private GetUserCartService _getUserCartService;
        public IGetUserCartService GetUserCart 
        {
            get
            {
                return _getUserCartService ?? new GetUserCartService(db,_mapper);
            }
        }

        private CreateCartService _createCartService;
        public ICreateCartService CreateCart
        {
            get
            {
                return _createCartService ?? new CreateCartService(db);
            }
        }

        private AddProductToCartService _addProductToCartService;
        public IAddProductToCartService AddProductToCart
        {
            get
            {
                return _addProductToCartService ?? new AddProductToCartService(db,_mapper);
            }
        }

        private EditProductCountService _editProductCountService;
        public IEditProductCountService EditProductCount
        {
            get
            {
                return _editProductCountService ?? new EditProductCountService(db);
            }
        }

        private DeleteCartService _deleteCartService;
        public IDeleteCartService DeleteCart
        {
            get
            {
                return _deleteCartService ?? new DeleteCartService(db);
            }
        }

        private DeleteProductFromCartService _deleteProductFromCartService;
        public IDeleteProductFromCartService DeleteProductFromCart
        {
            get
            {
                return _deleteProductFromCartService ?? new DeleteProductFromCartService(db);
            }
        }

        private AddCartPayingService _addCartPayingService;
        public IAddCartPayingService AddCartPaying
        {
            get
            {
                return _addCartPayingService ?? new AddCartPayingService(db,_mapper);
            }
        }

        private VerifyPayingService _verifyPayingService;
        public IVerifyPayingService VerifyPaying
        {
            get
            {
                return _verifyPayingService ?? new VerifyPayingService(db);
            }
        }
    }
}
