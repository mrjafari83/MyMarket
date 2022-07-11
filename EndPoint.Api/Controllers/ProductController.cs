using Application.Interfaces.FacadPatterns.Admin;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Admin.Products.Commands.CreateProduct;
using Common.ViewModels;
using Application.Services.Admin.Products.Queries.GetAllProducts;
using Application.Services.Admin.Products.Queries.GetProductById;
using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Common.Classes;
using Microsoft.AspNetCore.Http;
using EndPoint.Api.ViewModels.Products;
using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Cors;

namespace EndPoint.Api.Controllers
{
    [Authorize(Roles = "Admin,Owner")]
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class ProductController : ControllerBase
    {
        private readonly IProductFacad _productFacad;
        private readonly IMapper _Mapper;
        public ProductController(IProductFacad productFacad, IMapper mapper)
        {
            _productFacad = productFacad;
            _Mapper = mapper;
        }

        ///<summary>دریافت همه محصولات</summary>
        ///<response code="200">موفق</response>
        ///<response code="401">لطفا وارد سایت شوید</response>
        [HttpGet]
        public async Task<ResultGetAllProductsDto> GetAll([FromQuery]CompleteSearchViewModel model)
        {
            var result = await _productFacad.GetAllProductsService.Execute(model.PageNumber,model.PageSize, _Mapper.Map<Common.ViewModels.ProducsSearchViewModel>(model.Search));
            if (result.IsSuccess && result.Data.Products.Count() != 0)
                return result.Data;
           
            return new ResultGetAllProductsDto
            {
                Products = new List<GetAllProductDto>(),
                TotalRows = 0,
            };
        }

        ///<summary>دریافت یک محصول با استفاده از آیدی آن</summary>
        ///<response code="200">موفق</response>
        ///<response code="401">لطفا وارد سایت شوید</response>
        ///<response code="404">محصولی یافت نشد</response>
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productFacad.GetProductByIdService.Execute(id);
            if (result.IsSuccess && result.Data != null)
                return Ok(result.Data);
            return NotFound();
        }

        ///<summary>افزودن محصول جدید</summary>
        ///<response code="200">موفق</response>
        ///<response code="401">لطفا وارد سایت شوید</response>
        ///<response code="400">خطایی رخ داده است.</response>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] ViewModels.Products.CreateProductViewModel model)
        {
            var result = await _productFacad.CreateProductService.Execute(_Mapper.Map<CreateProductServiceDto>(model));

            if (result.IsSuccess)
                return Ok(result.Data);
            return BadRequest();
        }

        ///<summary>حذف محصول بر حسب آیدی آن</summary>
        ///<response code="200">موفق</response>
        ///<response code="401">لطفا وارد سایت شوید</response>
        ///<response code="404">محصولی یافت نشد.</response>
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productFacad.DeleteProductService.Execute(id);

            if (result.IsSuccess)
                return Ok();
            return NotFound();
        }
    }
}
