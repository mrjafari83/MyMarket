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

namespace Market.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class ProductController : Controller
    {
        private readonly IProductFacad _productFacad;
        private readonly IProductCategoryFacad _productCategoryFacad;
        private readonly ICommonCategorisFacad _commonCategorisFacad;
        public ProductController(IProductFacad productFacad
            , IProductCategoryFacad productCategoryFacad
            , ICommonCategorisFacad commonCategorisFacad)
        {
            _productFacad = productFacad;
            _productCategoryFacad = productCategoryFacad;
            _commonCategorisFacad = commonCategorisFacad;
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
            , List<ColorViewModel> colors, List<SizeViewModel> sizes, List<FeatureViewModel> features)
        {
            if (ModelState.IsValid)
            {
                _productFacad.CreateProductService.Execute(new CreateProductServiceDto
                {
                    Name = request.Name,
                    Brand = request.Brand,
                    ShortDescription = request.ShortDescription,
                    Description = request.Description,
                    Inventory = request.Inventory,
                    Price = request.Price,
                    CategoryId = request.CategoryId,
                    Keywords = Keywords,
                    Colors = colors,
                    Sizes = sizes,
                    Features = features,
                    Images = request.Images
                });

                return Redirect("/Admin/Product");
            }

            return View();
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
            , List<ColorViewModel> colors, List<SizeViewModel> sizes, List<FeatureViewModel> features)
        {
            _productFacad.EditProductService.Execute(new EditProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Brand = product.Brand,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                Price = product.Price,
                Inventory = product.Inventory,
                CategoryId = product.CategoryId,
                Images = product.Images,
                Keywords = Keywords,
                Colors = colors,
                Sizes = sizes,
                Features = features
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
