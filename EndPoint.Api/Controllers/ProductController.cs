using Application.Interfaces.FacadPatterns.Admin;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Admin.Products.Commands.CreateProduct;
using Common.ViewModels;
using Application.Services.Admin.Products.Queries.GetAllProducts;
using Application.Services.Admin.Products.Queries.GetProductById;
using Common.Enums;

namespace EndPoint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductFacad _productFacad;
        public ProductController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        [HttpGet]
        public async Task<ResultGetAllProductsDto> GetAll(int pageNumber, int pageSize,[FromQuery]SearchViewModel searchViewModel)
        {
            var result = await _productFacad.GetAllProductsService.Execute(pageNumber, pageSize, searchViewModel);
            if (result.IsSuccess && result.Data.Products.Count() != 0)
                return result.Data;
            return new ResultGetAllProductsDto
            {
                Products = new List<GetAllProductDto>(),
                TotalRows = 0,
            };
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<GetProductByIdDto> GetAll(int id)
        {
            var result = await _productFacad.GetProductByIdService.Execute(id);
            if (result.IsSuccess && result.Data != null)
                return result.Data;
            return new GetProductByIdDto() { };
        }


        [HttpPost]
        [Route("Create")]
        public async Task<bool> Create([FromBody] CreateProductServiceDto model)
        {
            var result = await _productFacad.CreateProductService.Execute(model);

            if (result.IsSuccess)
                return true;
            return false;
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<bool> Delete(int id)
        {
            var result = await _productFacad.DeleteProductService.Execute(id);

            if (result.IsSuccess)
                return true;
            return false;
        }

        public enum ProductType
        {
            mobile,
            computer
        }
    }
}
