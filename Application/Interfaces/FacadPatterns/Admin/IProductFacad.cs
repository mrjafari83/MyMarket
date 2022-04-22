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

namespace Application.Interfaces.FacadPatterns.Admin
{
    public interface IProductFacad
    {
        IGetAllProductsService GetAllProductsService { get; }
        IGetProductByIdService GetProductByIdService { get; }
        ICreateProductService CreateProductService { get; }
        IEditProductService EditProductService { get; }
        IDeleteProductService DeleteProductService { get; }
        IGetBestSellingProductsService GetBestSellingProducts { get; }
    }
}
