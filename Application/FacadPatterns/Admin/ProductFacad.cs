using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Admin.Products.Commands.CreateProduct;
using Application.Services.Admin.Products.Commands.EditProduct;
using Application.Services.Admin.Products.Commands.DeleteProduct;
using Application.Services.Admin.Products.Queries.GetAllProducts;
using Application.Services.Admin.Products.Queries.GetProductById;
using Application.Services.Admin.Products.Queries.GetBestSellingProducts;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.Context;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;

namespace Application.FacadPatterns.Admin
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDataBaseContext db;
        private readonly IHostingEnvironment _environment;
        private readonly IMapper _mapper;
        public ProductFacad(IDataBaseContext context
            , IHostingEnvironment environment , IMapper mapper)
        {
            db = context;
            _environment = environment;
            _mapper = mapper;
        }

        private GetAllProductsService _getAllProductsService;
        public IGetAllProductsService GetAllProductsService
        {
            get
            {
                return _getAllProductsService == null ? new GetAllProductsService(db,_mapper) : _getAllProductsService;
            }
        }

        private GetProductByIdService _getProductByIdService;
        public IGetProductByIdService GetProductByIdService
        {
            get
            {
                return _getProductByIdService == null ? new GetProductByIdService(db , _mapper) : _getProductByIdService;
            }
        }

        private CreateProductService _createProductService;
        public ICreateProductService CreateProductService
        {
            get
            {
                return _createProductService == null ? new CreateProductService(db , _environment , _mapper) : _createProductService;
            }
        }

        private EditProductService _editProductService;
        public IEditProductService EditProductService
        {
            get
            {
                return _editProductService == null ? new EditProductService(db , _environment) : _editProductService;
            }
        }

        private DeleteProductService _deleteProductService;
        public IDeleteProductService DeleteProductService
        {
            get
            {
                return _deleteProductService == null ? new DeleteProductService(db) : _deleteProductService;
            }
        }

        private GetBestSellingProductsService _getBestSellingProductsService;
        public IGetBestSellingProductsService GetBestSellingProducts
        {
            get
            {
                return _getBestSellingProductsService ?? new GetBestSellingProductsService(db,_mapper);
            }
        }
    }
}
