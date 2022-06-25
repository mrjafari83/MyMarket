using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.FacadPatterns.Admin;
using Application.Interfaces.FacadPatterns.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Common.Enums;
using Common.Classes;
using Common.ViewModels;
using Application.Services.Admin.Products.Commands.CreateProduct;
using Application.Services.Admin.Products.Commands.EditProduct;
using Application.Services.Admin.Products.Commands.DeleteProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Domain.Entities.Products;
using Market.EndPoint.Utilities;

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class ProductController : Controller
    {
        private readonly IProductFacad _productFacad;
        private readonly IProductCategoryFacad _productCategoryFacad;
        private readonly ICommonCategorisFacad _commonCategorisFacad;
        private readonly IMapper _mapper;
        private readonly IGetProductDetailsExcel _getProductDetailsExcel;

        public ProductController(IProductFacad productFacad
            , IProductCategoryFacad productCategoryFacad
            , ICommonCategorisFacad commonCategorisFacad, IMapper mapper
            , IGetProductDetailsExcel getProductDetailsExcel)
        {
            _productFacad = productFacad;
            _productCategoryFacad = productCategoryFacad;
            _commonCategorisFacad = commonCategorisFacad;
            _mapper = mapper;
            _getProductDetailsExcel = getProductDetailsExcel;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int currentPage = 1, string searchKey = "", int startPrice = 0
            , int endPrice = 0, Enums.PagesFilter orderBy = Enums.PagesFilter.Newest, Enums.PageFilterCategory searchBy = Enums.PageFilterCategory.Name
            )
        {
            ViewBag.CurrentRow = currentPage;
            ViewBag.SearchKey = searchKey;
            ViewBag.StartPrice = startPrice;
            ViewBag.EndPrice = endPrice;
            ViewBag.OrderBy = (int)orderBy;
            ViewBag.SearchBy = (int)searchBy;

            return View(await _productFacad.GetAllProductsService.Execute(currentPage, 10, startPrice, endPrice, searchKey
                , searchBy, orderBy));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.categories = new SelectList(
                _commonCategorisFacad.GetAllProductCategories.Execute(false, Enums.CategoriesFilter.ForPagesList).Data
                , "Id"
                , "Name"
                );

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel request, List<KeywordViewModel> Keywords
            , List<ColorViewModel> colors, List<SizeViewModel> sizes, List<FeatureViewModel> features
            , List<InventoryAndPriceViewModel> inventoryAndPrice, List<IFormFile> Images)
        {
            await _productFacad.CreateProductService.Execute(new CreateProductServiceDto
            {
                Product = request,
                Keywords = Keywords,
                Colors = colors,
                Sizes = sizes,
                Features = features,
                Images = Images,
                InventoryAndPrices = inventoryAndPrice
            });

            return Json(true);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.categories = new SelectList(
                _commonCategorisFacad.GetAllProductCategories.Execute(false, Enums.CategoriesFilter.ForPagesList).Data
                , "Id"
                , "Name"
                );

            var product = await _productFacad.GetProductByIdService.Execute(id);
            if (product.IsSuccess)
                return View(product.Data);
            else
                return Redirect("/Admin/NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel product, List<KeywordViewModel> Keywords
            , List<ColorViewModel> colors, List<SizeViewModel> sizes, List<FeatureViewModel> features
            , List<InventoryAndPriceViewModel> inventoryAndPrice, List<IFormFile> Images)
        {
            await _productFacad.EditProductService.Execute(new EditProductDto
            {
                Product = product,
                Images = Images,
                Keywords = Keywords,
                Colors = colors,
                Sizes = sizes,
                Features = features,
                InventoryAndPrices = inventoryAndPrice
            });

            return Redirect("/Admin/Product");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productFacad.GetProductByIdService.Execute(id);
            if (product.IsSuccess)
                return View(product.Data);
            else
                return Redirect("/Admin/NotFound");
        }

        [HttpGet]
        public async Task<IActionResult> Deleting(int id)
        {
            await _productFacad.DeleteProductService.Execute(id);

            return Redirect("/Admin/Product");
        }

        [HttpPost]
        public async Task<IActionResult> GetExcel(List<int> Ids)
        {
            var address = await _getProductDetailsExcel.GetProductDetails(Ids);
            return Json(address);
        }
    }

}
