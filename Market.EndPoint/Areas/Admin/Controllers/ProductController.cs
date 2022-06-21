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

        public ProductController(IProductFacad productFacad
            , IProductCategoryFacad productCategoryFacad
            , ICommonCategorisFacad commonCategorisFacad , IMapper mapper)
        {
            _productFacad = productFacad;
            _productCategoryFacad = productCategoryFacad;
            _commonCategorisFacad = commonCategorisFacad;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(int currentPage = 1)
        {
            ViewBag.CurrentRow = currentPage;
            return View(_productFacad.GetAllProductsService.Execute(currentPage, 10).Data);
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
        public IActionResult Create(ProductViewModel request, List<KeywordViewModel> Keywords
            , List<ColorViewModel> colors, List<SizeViewModel> sizes, List<FeatureViewModel> features
            , List<InventoryAndPriceViewModel> inventoryAndPrice, List<IFormFile> Images)
        {
                _productFacad.CreateProductService.Execute(new CreateProductServiceDto
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
        public IActionResult Edit(int id)
        {
            ViewBag.categories = new SelectList(
                _commonCategorisFacad.GetAllProductCategories.Execute(false, Enums.CategoriesFilter.ForPagesList).Data
                , "Id"
                , "Name"
                );

            var product = _productFacad.GetProductByIdService.Execute(id);
            if (product.IsSuccess)
                return View(product.Data);
            else
                return Redirect("/Admin/NotFound");
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel product, List<KeywordViewModel> Keywords
            , List<ColorViewModel> colors, List<SizeViewModel> sizes, List<FeatureViewModel> features
            ,List<InventoryAndPriceViewModel> inventoryAndPrice ,List<IFormFile> Images)
        {
            _productFacad.EditProductService.Execute(new EditProductDto
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
        public IActionResult Delete(int id)
        {
            var product = _productFacad.GetProductByIdService.Execute(id);
            if (product.IsSuccess)
                return View(product.Data);
            else
                return Redirect("/Admin/NotFound");
        }

        [HttpGet]
        public IActionResult Deleting(int id)
        {
            _productFacad.DeleteProductService.Execute(id);

            return Redirect("/Admin/Product");
        }
    }

}
